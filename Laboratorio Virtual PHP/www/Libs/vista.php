<?php

class Vista{

    //Basicamente la unica funcion que nesesitaremos de vista es mandarla
    //a dibujar, decidimos cual a travez de la variables "vista"
    function render(string $vista){
        $r = 'vistas/' . $vista . '.php';
        if(file_exists($r))
            require_once $r;
    }
}

?>