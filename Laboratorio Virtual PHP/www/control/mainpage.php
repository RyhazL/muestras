<?php

class MainPage extends Control{

    function __construct(){
        parent::__construct();
    }

    function Main(){
        parent::cargarModelo('users');
        $users = $this->model->getUsers(8);
        parent::cargarModelo('posts');
        $publicaciones = $this->model->VerPublicaciones(0,8);
        $this->vista->users = $users;
        $this->vista->publi = $publicaciones;
        $this->vista->render('main/index');
    }

}


?>