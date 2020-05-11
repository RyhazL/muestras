<?php

class Usuario extends Control{

    function __construct(){
        parent::__construct();
    }

    function Main(){
        $this->Redirect('/');
    }

    function Perfil($url){
        if(isset($url[2])){
            parent::cargarModelo('users');
            $resultado = $this->model->VerUsuario($url[2]);
            parent::cargarModelo('posts');
            $publicaciones = $this->model->BuscarporAutorID($url[2]);
            if($resultado == false){
                $err = new Err('Esta ID no pertenece a ningun usuario.');
            }else{
                $this->vista->idperfil = $url[2];
                $this->vista->nombre = $resultado[0]['nombre'].', '.$resultado[0]['apellido'];
                $this->vista->tipoperfil = $resultado[0]['tipo'];
                $this->vista->publi = $publicaciones;
                $this->vista->render('perfil/index'); 
            }
        }else{
            $error = new Err('Falta id de usuario en la URL','/');
        } 
    }

}



?>