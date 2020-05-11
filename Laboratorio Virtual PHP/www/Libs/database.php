<?php

class Database{

    private $host;
    private $user;
    private $password;
    private $charset;
    private $mysqli;

    public function __construct(){
        $this->host = constant('HOST');
        $this->db = constant('DB');
        $this->user = constant('USER');
        $this->password = constant('PASSWORD');
        $this->charset = constant('CHARSET');
    }

    function resQuery($sqlquery){
        $mysqli = new mysqli($this->host, $this->user, $this->password, $this->db);

        if ($mysqli->connect_error) {
            return 'Connect Error (' . $mysqli->connect_errno . ') '. $mysqli->connect_error;
        }
        $data = array();
        if ($resultado = $mysqli->query($sqlquery)) {
            while ($fila = $resultado->fetch_assoc()) {
                array_push($data,$fila);
            }
            $resultado->free();
        }else{
            return false;
        }
        $mysqli->close();
        return $data;
    }

    function noresQuery($sqlquery){
        $mysqli = new mysqli($this->host, $this->user, $this->password, $this->db);

        if ($mysqli->connect_error) {
            return 'Connect Error (' . $mysqli->connect_errno . ') '. $mysqli->connect_error;
        }
        $resultado = $mysqli->query($sqlquery);
        return $resultado;
    }
}

?>