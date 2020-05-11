<?php

class Err extends Control{

    function __construct(string $desc,$url){
        parent::__construct();
        $this->vista->mensage = $desc;
        $this->vista->url = constant('URLHOST').$url;
        $this->vista->render('errorpage/index');
        exit;
    }

}


?>