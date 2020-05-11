<?php

class Control{

    //constructor, añade las variables segun la sesion a la vista,
    //lo que hace posible ver el nombre y lo iconos de la cabecera de la pagina
    function __construct(){
        $this->vista = new Vista();
        $this->vista->logged = $_SESSION['logged'];
        $this->vista->nombre = $_SESSION['nombre'];
        $this->vista->tipo = $_SESSION['userType'];
        $this->vista->id = $_SESSION['id'];

    }

    //A diferencia de la instancia de la vista como se vio en el constructor
    //el modelo no se instancia hasta que se ordena, pues hay condiciones
    //en las que no es nesesario usar el modelo por eso creamos la funcion
    // "cargarModelo" para cargar el modelo en cualquier controlador con solo
    //el onmbre
    function cargarModelo($nombre){
        $url = 'modelos/'.$nombre.'_model.php';

        if(file_exists($url)){
            require $url;

            $nombreModelo = $nombre.'Model';
            $this->model = new $nombreModelo();
            return true;
        }
        return false;
    }

    //Una funcion que sirve para redireccionar a otra parte de esta misma pagina
    //segun el valor que se especifica en "url".
    function Redirect($url){
        header('Location: '.constant('URLHOST').$url);
        exit;
    }

    //Desde donde se llame esta funcion, se revisara si se esta enviando informacion
    //de un formulario sino, se redirecciona a otra parte. El uso de esto es para dedicar
    //ciertas URL del sitio a funtionar solo si se les paso la informacion requeria atraves
    //de un formulario o input (Metodo POST y no GET)
    function OnlyPostUri($formdataname,$redirect){
        if(isset($_POST[$formdataname]))
            return;
        else
            $this->Redirect($redirect);
    }

    //Hay nivles de acceso segun el tipo de usuario, sinendo la variable $index el valor minimo
    //permitido para ver el contenido, $redirect es para especificar si se redirecionara o no,
    //$ulr hacia donde se redirecionara.
    function OnlyAccessLevel($index,$redirect,$url){
        if($_SESSION['userType'] >= $index)
            return;
        else{
            if($redirect === false){
                $r = new Err('No tienes permiso para eso.',$url);
            }else{
                $this->Redirect($url);
            }
        }
    }
}

?>