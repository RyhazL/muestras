<?php

class postsModel extends Modelo{

    function Publicar($Titulo,$contenido,$idAutor){
        $id = uniqid();
        $fecha = date('Y-m-d');
        $contenido = $this->Postdata_EasyData($contenido);
        $sqlquery = "INSERT INTO posts(id,nombre,contenido,id_autor,fecha) 
        VALUES ('$id','$Titulo','$contenido','$idAutor','$fecha')";
        $res = $this->db->noresQuery($sqlquery);
        if($res)
            return $id;
        else
            return false;
    }
    function Eliminar($id){
        $sqlquery = "DELETE FROM posts WHERE id='$id'";
        return $this->db->noresQuery($sqlquery);
    }

    function Editar($Titulo,$contenido,$id){
        $contenido = $this->Postdata_EasyData($contenido);
        $sqlquery = "UPDATE posts SET nombre='$Titulo',contenido='$contenido' WHERE id='$id'";
        echo $sqlquery;
        if($this->db->noresQuery($sqlquery))
            return $id;
        else
            return false;
    }
    function BuscarconID($id){
        $sqlquery = "SELECT id,nombre,contenido,id_autor,fecha FROM posts WHERE id='$id'";
        $r = $this->db->resQuery($sqlquery);
        if($r == false){
            return false;
        }
        $r[0]['contenido'] = $this->EasyData_Postdata($r[0]['contenido']);
        return $r;
    }

    function VerPublicaciones($offset,$num){
        $sqlquery = "SELECT id,nombre FROM posts ORDER BY fecha ASC LIMIT $offset,$num";
        $r = $this->db->resQuery($sqlquery);
        return $r;
    }

    function BuscarporAutorID($id){
        $sqlquery = "SELECT id,nombre FROM posts WHERE id_autor='$id'";
        $r = $this->db->resQuery($sqlquery);
        return $r;
    }

    function NumeroDePublicacoines(){
        $sqlquery = "SELECT COUNT(*) FROM posts";
        return $this->db->resQuery($sqlquery)[0]['COUNT(*)'];
    }
}

?>