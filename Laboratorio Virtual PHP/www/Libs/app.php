<?php

class App {

    function __construct(){

        //hacemos requirea Err(Clase error) para ejecutarla si algo sale mal.
        require_once 'control/err.php';

        //si el visitante es nuevo o no a ingresado sesion con esto PHP se encargara
        //de que tenga acceso solo a las caracteristicas de visitante.
        session_start();
        if(!isset($_SESSION['userType']))
            $_SESSION['userType'] = 0;
        if(!isset($_SESSION['logged']))
            $_SESSION['logged'] = false;
        if(!isset($_SESSION['nombre']))
            $_SESSION['nombre'] = '';
        if(!isset($_SESSION['id']))
            $_SESSION['id'] = 0;

        
        //como se vio en el desglocse de la url, ya que la tenemo almacenada como
        // URL: /urlprimergrado/urlsegundogrado...etc, pero primero vemos si hay desgloce
        //pues si no hay dicha variables, vamos a al pagina principal.
        if(isset($_GET['url'])){
            $url = $_GET['url'];
            $url = rtrim($url,'/');
            $url = explode('/',$url);

            // si hay una direccion subsecuente al dominio buscar el controlador en base a 
            //ella viendo si existe un archivo con su nombre, si no se encentra
            //manda a unaa pagina de error (con la clase Err) diciendo "ERROR: URL Invalida" o 
            //"ERROR: Sub-URL Invalida" dependiendo del grado de la URL
            $archivodecontorl = 'control/' . $url[0] . '.php';
            if(file_exists($archivodecontorl)){
                require_once $archivodecontorl;
                $control = new $url[0]();
                if(isset($url[1])){
                    if(method_exists($control,$url[1])){
                        $control->{$url[1]}($url);
                        exit;
                    }   
                }
                $control->Main($url);
            }else{
                $control = new Err('ERROR: URL Invalida','/');
            }
        }else{

            //aqui es donde se dirije si no hay como minimo una URL de 
            //primer grado, que es la Pagina principal, por eso es un aso especial.
            require_once 'control/mainpage.php';
            $control = new MainPage();
            $control->Main();
        }
    }

}

?>