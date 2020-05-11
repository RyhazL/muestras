<?php

class Login extends Control{


    function __construct(){
        parent::__construct();
    }

    function Main(){
        if($_SESSION['userType'] > 0){
            parent::Redirect('');
        }
        $this->vista->render('login/index');
    }

    function AuthIn(){
        if($_SESSION['userType'] > 0){
            parent::Redirect('/');
        }
        if(isset($_POST['user']) && isset($_POST['pass'])){
            $usr = $_POST['user'];
            $pss = $_POST['pass'];
            if(parent::cargarModelo('users')){
                $respuesta = $this->model->LoginAuth($usr,$pss);
                if($respuesta == 'nor'){
                    $this->vista->AuthErr = 'Correo incorrecto.';
                    $this->vista->render('login/index');
                    exit;
                }
                if($respuesta == 'pss'){
                    $this->vista->AuthErr = 'Clave incorrecto.';
                    $this->vista->render('login/index');
                    exit;
                }
                
                $_SESSION['userType'] = $respuesta['tipo'];
                $_SESSION['nombre'] = $respuesta['nombre'].', '.$respuesta['apellido'];
                $_SESSION['logged'] = true;
                $_SESSION['id'] = $respuesta['id'];
                parent::Redirect('/');
                
            }else{
                $err = new Err('Error: NO se pudo iniciar sesion inentalo de nuevo','/login');
            }
        }else{
            parent::Redirect('/login');
        }
    }

    function AuthOut(){

        if($_SESSION['userType'] > 0){
            $_SESSION['userType'] = 0;
            $_SESSION['logged'] = false;
            $_SESSION['nombre'] = '';
            $_SESSION['id'] = 0;
        }
        parent::Redirect('');
        exit;
    }

}


?>