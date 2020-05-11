<?php

class CodeEditor extends Control{

    function __construct(){
    }

    function Main(){
        if(isset($_POST['codigo'])){
            $codestring = $_POST['codigo'];
            eval($codestring);
        }
    }
}


?>