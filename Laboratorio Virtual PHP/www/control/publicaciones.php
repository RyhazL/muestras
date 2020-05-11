<?php

class Publicaciones extends Control{

    function __construct(){
        parent::__construct();
    }

    function Main($url){

        parent::cargarModelo('posts');
        $offset = 0;
        $limite = 2;
        $pagactual = 1;
        $pagtotal = 1;
        
        $numPubli = $this->model->NumeroDePublicacoines();
        $pgtotaldecimal = $numPubli/$limite;
        $pagtotal = round($pgtotaldecimal);
        if(isset($url[1])){
        
            $urlint = (int)$url[1];
            if($urlint > $pagtotal){
                $this->Redirect('/publicaciones');
            }
            $pagactual = $url[1];
        }
        $offset = $limite * ($pagactual - 1) ;

        $publicaciones = $this->model->VerPublicaciones($offset,$limite);
        $this->vista->publi = $publicaciones;
        $this->vista->pagactual = $pagactual;
        $this->vista->numpag = $pagtotal;
        $this->vista->render('publicaciones/index');
    }

    function Nueva(){
        
        $this->OnlyAccessLevel(1,false,'/');
        $this->vista->render('publicaciones/nueva');
    }

    function Ver($url){
        
        if(isset($url[2])){
            parent::cargarModelo('posts');
            $r = $this->model->BuscarconID($url[2])[0];
            if($r == false){
                $error = new Err('Esta publicacion no existe.','/publicaciones');
            }else{
                $this->vista->titulo = $r['nombre'];
                $this->vista->contenido = $r['contenido'];
                parent::cargarModelo('users');
                $r2 = $this->model->VerUsuario($r['id_autor'])[0];
                if($r2 == false){
                    $this->vista->nombre = ''; 
                }else{
                    $this->vista->nombre = $r2['nombre'].' '.$r2['apellido'];
                }
                $this->vista->footer = 'Publicado: '.$r['fecha'].'    Por: '.$this->vista->nombre;
                $this->vista->ispreview = false;
                $this->vista->render('publicaciones/ver');
            }
        }else{
            $this->Redirect('/publicaciones');
        }
    }

    function Editar($url){
        
        $this->OnlyAccessLevel(1,false,'/publicaciones');


        if(isset($url[2])){
            parent::cargarModelo('posts');
            $r = $this->model->BuscarconID($url[2])[0];
            if($r == false){
                $error = new Err('La publicacion que deseas editar no existe.','/publicaciones');
            }else{
                $this->vista->titulo = $r['nombre'];
                $this->vista->contenido = $r['contenido'];
                $this->vista->id_publicacion = $url[2];
                parent::cargarModelo('users');
                $this->vista->render('publicaciones/editar');
            }
        }else{
            $this->Redirect('/publicaciones');
        }
    }

    function EditData($id){
        $this->OnlyAccessLevel(1,true,'/publicaciones');
        $this->OnlyPostUri('newpost','/publicaciones');
        $data = $_POST['newpost'];
        parent::cargarModelo('posts');
            $r = $this->model->Editar($data['titulo'],$data['contenido'],$id[2]);
            if(!$r)
                $error = new Err('No se pudo editar la publicacion, intentalo de nuevo','/publicaciones/nueva');
            else
                $this->Redirect('/publicaciones/ver/'.$r);

    }
    function PostData($url){
        
        //si no se usa esa URL con un formulario o si no se tiene el nivel de
        //acceso adecuado, redirecciona a otra parte segun la URL ntroducida.
        $this->OnlyAccessLevel(1,true,'/publicaciones/nueva');
        $this->OnlyPostUri('newpost','/publicaciones/nueva');
        
        $data = $_POST['newpost'];
        
        // si se le añadio a la URL "/preview" pasa por aqui, para visualizar una vista
        //previa de la publicacion.
        if(isset($url[2])){
            if($url[2] == 'preview'){
                $this->vista->titulo = $data['titulo'];
                $this->vista->contenido = $data['contenido'];
                $this->vista->logged = false;
                $this->vista->ispreview = true;
                $this->vista->footer = 'Publicado: '.date('Y-m-d').' - Por: '.$this->vista->nombre;
                $this->vista->render('publicaciones/ver');
                exit;
            }
        }else{   
            //Sino carga el modelo "post_model" y lo mandamos a la base de datos, si sale bien el proceso,
            //redirecciona a esa misma nueva publicacion que se creo. Si sale mal mandara un error
            // diciend que lo inente de nuevo
            parent::cargarModelo('posts');
            $r = $this->model->Publicar($data['titulo'],$data['contenido'],$_SESSION['id']);
            if(!$r)
                $error = new Err('No se pudo crear la publicacion, intentalo de nuevo','/publicaciones/nueva');
            else
                $this->Redirect('/publicaciones/ver/'.$r);
        }
        
    }
    function Eliminar($url){
        parent::cargarModelo('posts');
        $autor;
        if(!isset($url[2])){
            $error = new Err('No se pudo eliminar','/');
        }
        if(!$_SESSION['userType'] == 4){
            $r = $this->model->BuscarconID($url[2])[0];
            if(!$r){
                $error = new Err('No se encuentra la publicacion','/publicaciones/nueva');
            }
            if(!$r['id_autor'] == $_SESSION['id']){
                $this->Redirect('/usuario/perfil/'.$_SESSION['id']);
            }
            $autor = $r['id_autor'];
        }
        if($this->model->Eliminar($url[2])){
            $this->Redirect('/usuario/perfil/'.$_SESSION['id']);
        }else{
            $error = new Err('No se pudo eliminar la publicacion por que on existe','/');
        }
    }
}


?>