<?php

class Modelo{

    function __construct(){
        $this->db = new Database();
    }

    //Hay cierto caracteres cuando se trabaja con string que PHP o inclusive la bae
    //de datos mal interpreta, por eso lo paasmos a un modo mas fail de interpretar
    //los dos metodos son lo mismo solo que imentras uno concierte, el otro reconstrulle.
    function Postdata_EasyData($data){
        $search = array("~","`","!","@","#","\$","%","^","&","*","(",")","_","-","+","=","{",
            "[","}","]","|","\\",":",";",'"',"'","<",",",">",".","?","/");
        $replace = array("&c1;","&c2;","&c3;","&c4;","&c5;","&c6;","&c7;","&c8;",
            "&c9;","&_1;","&_2;","&_3;","&_4;","&_5;","&_6;","&_7;","&_8;",
            "&_9;","&a1;","&a2;","&a3;","&a4;","&a5;","&a6;","&a7;","&a8;",
            "&1;","&b1;","&b2;","&b3;","&b4;","&b5;");
        return strtr($data, $this->convertArray($search, $replace));
    }
    function EasyData_Postdata($data){
        $search = array("~","`","!","@","#","\$","%","^","&","*","(",")","_","-","+","=","{",
            "[","}","]","|","\\",":",";",'"',"'","<",",",">",".","?","/");
        $replace = array("&c1;","&c2;","&c3;","&c4;","&c5;","&c6;","&c7;","&c8;",
            "&c9;","&_1;","&_2;","&_3;","&_4;","&_5;","&_6;","&_7;","&_8;",
            "&_9;","&a1;","&a2;","&a3;","&a4;","&a5;","&a6;","&a7;","&a8;",
            "&1;","&b1;","&b2;","&b3;","&b4;","&b5;");
        return strtr($data, $this->convertArray($replace,$search));
    }
    function convertArray($search, $replace){
        $return = array();
        foreach ($search as $key=>$val){
            $return[$val] = $replace[$key];
        }
        return $return;
    }
}

?>