<?php

class SingIn extends Control{

    function __construct(){
        parent::__construct();
    }

    function Main(){
        if($_SESSION['userType'] > 0){
            parent::Redirect('');
        }
        $this->vista->render('singin/index');
    }
    function Auth(){
        
        if(parent::cargarModelo('users')){
            $i = 0;
            if(isset($_POST['name'])){
                $nombre = $_POST['name'];
                if(!$nombre == '')  $i++;
            }
            if(isset($_POST['lastname'])){
                $apellido = $_POST['lastname'];
                if(!$apellido == '')  $i++;
            }
            if(isset($_POST['correo'])){
                $correo = $_POST['correo'];
                if(!$correo == '')  $i++;
            }
            if(isset($_POST['clave'])){
                $clave = $_POST['clave'];
                if(!$clave == '')  $i++;
            }
            // 0 significa no registrado, mientras que 2 registrado, 3 especializado, 4 administrador.
            $tipo = 1;
            if($i == 4){
                $succes = $this->model->RegistrarUsurario($nombre,$apellido,$correo,$clave,$tipo);
                if($succes == true){
                    parent::Redirect('/login');
                }else{
                    $err = new Err('No se pudo registrar la informacion en la Base de Datos. '.$succes);
                }
            }else{
                $this->vista->AuthErr = 'Debes rellenar todos los campos.';
                $this->vista->render('singin/index');
            }
        }else{
            $err = new Err('Error al cargar el Modelo de Usuarios','/');
        }
    }
}
?>