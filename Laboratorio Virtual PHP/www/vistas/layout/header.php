<!DOCTYPE html>
    <html>
        <head>
            <meta charset="UTF-8">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
            <meta http-equiv="X-UA-Compatible" content="ie=edge">
            <title>LABORATOROI VIRTUAL</title>
            <link rel="stylesheet" href="/public/css/materialize.min.css">
            <link rel="stylesheet" href="/public/css/style.css">
            <link rel="stylesheet" href="/public/css/icons.css">
            <script src="/public/js/materialize.min.js"></script>
            <script src="/public/js/init.js"></script>
        </head>
        <body class="base" style="background: url(/public/img/fondo.jpg);">
            <header class="cabeza">
                <a class="brw fltL m5" href="#">
                    <i class="fab fa-google-plus-square fa-2x"></i>
                </a>
                <a class="brw fltL m5" href="#">
                    <i class="fab fa-twitter-square fa-2x"></i>
                </a>
                <a class="brw fltL m5" href="#">
                    <i class="fab fa-facebook fa-2x"></i>
                </a>
                <div class="barra fltL"></div>
                <a href="/"><span class="fltL">LABORATORIO VIRTUAL</span></a>
                <?php
                    if($this->logged === true){
                        echo '<a class="brw m5 fltR tooltipped" data-position="bottom" data-tooltip="Cerrar session" 
                        href="/login/authout"><i class="fas fa-sign-in-alt fa-2x"></i></a>';
                        echo '<a class="brw m5 fltR tooltipped" data-position="bottom" data-tooltip="Ir a Perfil" 
                        href="/usuario/perfil/'.$this->id.'"><i class="fas fa-address-card fa-2x"></i></a>';
                        echo '<span class="brw m5 fltR">'.$this->nombre.'</span>';
                        echo '<div class="barra fltR"></div>';
                        echo '<a class="brw m5 fltR tooltipped" data-position="bottom" data-tooltip="Crear nueva publicacion" 
                        href="/publicaciones/nueva"><i class="fas fa-plus-square fa-2x"></i></a>';
                        echo '<a class="brw m5 fltR tooltipped" data-position="bottom" data-tooltip="Buscar" 
                        href="/publicaciones"><i class="fas fa-search fa-2x"></i></a>';
                        
                    }else{
                        echo '<a class="brw m5 fltR tooltipped" data-position="bottom" data-tooltip="Inicia sesion o Registrate" 
                        href="/login"><i class="fas fa-sign-in-alt fa-2x"></i></a>';  
                    }
                ?>
            </header>
        </body>
    </html>