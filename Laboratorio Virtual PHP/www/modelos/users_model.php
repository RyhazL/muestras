<?php

class usersModel extends Modelo{

    function LoginAuth($correo,$clave){
        $sqlquery = "SELECT clave,tipo,nombre,apellido,id FROM usuario WHERE Correo LIKE '$correo'";
        $r = $this->db->resQuery($sqlquery);
        if($r == false)
            return 'nor';
        $data = $r[0];
        if($data['clave'] == $clave){
            return $data;
        }else{
            return 'pss';
        }
    }
    function VerUsuario($id){
        $sqlquery = "SELECT tipo,nombre,apellido FROM usuario WHERE id LIKE '$id'";
        $r = $this->db->resQuery($sqlquery);
        return $r;
    }
    function RegistrarUsurario($nom,$apell,$correo,$clave,$tipo){
        $id = uniqid();
        $sqlquery = "INSERT INTO usuario (Nombre, Apellido, Correo, clave, tipo, id, descr) 
        VALUES ('$nom', '$apell', '$correo', '$clave', $tipo, '$id', '')";
        $res = $this->db->noresQuery($sqlquery);
        return $res;
    }
    function getUsers($limit){
        $sqlquery = "SELECT tipo,nombre,apellido,id FROM usuario ORDER BY id ASC LIMIT $limit";
        $r = $this->db->resQuery($sqlquery);
        return $r;
    }
}


?>