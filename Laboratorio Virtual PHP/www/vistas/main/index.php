<?php require 'vistas/layout/header.php' ?>
    <div class="realbody">
        <div class="mainBox mbfixed">
            <h2 class="center">¡Bienvenido <?php echo 'de nuevo '.$this->nombre?>!</h2>
            <div class="row">
                <div class="col s4 center">
                    <i class="fas fa-code fa-7x"></i>
                    <h4>Interpreta PHP</h4>
                    <p>Cualquier codigo, escribeo en el panel de abajo y oprime ¡Correr codigo!</p>
                </div>
                <div class="col s4 center">
                    <i class="fab fa-weixin fa-7x"></i>
                    <h4>Compartelo</h4>
                    <p>Puesde compartir tu codigo con quien quieras o inclusive pedir ayuda a otros usuarios</p>
                </div>
                <div class="col s4 center">
                    <i class="fas fa-tachometer-alt fa-7x"></i>
                    <h4>Rapido</h4>
                    <p>Corre y edita el codigo cuantas vecez quieras, con resltados inmediatos.</p>
                </div>
            </div>
            <?php 
            $this->codigophp = "echo 'Hola mundo';";
            require 'vistas/codeeditor/index.php'; 
            ?> 
            <div class="row">
                <a href="/publicaciones" class="col s10 push-s1 btn waves-effect waves-light indigo darken-4 center">Ver todas las publicciones</a>
            </div>
            <!-- Seccion donde ese muestra las ultimas publicaciones agregadas -->  
            <div class="row">
                <div class="col s6">
                    <h4 class="center">Ultimas publicaciones agregadas:</h4>
                    <?php
                    $publicaciones = $this->publi;
                    if(is_array($publicaciones)){
                        $a = 0;
                        $inx = count($publicaciones);
                        while ($a < $inx) {
                            $r = $publicaciones[$a]['nombre'];
                            echo '<a class="prestlink" href="/publicaciones/ver/'.
                            $publicaciones[$a]['id'].'">'.$r.'</a>';
                            $a++;
                        }
                    }
                    if($a == 0){
                        echo '<p>No se encuentran Publicaciones actualmente</p>';
                    }
                    ?>
                </div>
                <!-- Seccion donde ese muestra los ultimo usuarios registrados --> 
                <div class="col s6">
                    <h4 class="center">Ultimos usuarios registrados:</h4>
                    <?php
                    $du = $this->users;
                    if(is_array($du)){
                        $a = 0;
                        $inx = count($du);
                        while ($a < $inx) {
                            $tipo;
                            switch ($du[$a]['tipo']) {
                                case 4:
                                    $tipo = '[ADMIN] - ';
                                    break;
                                
                                default:
                                    $tipo = '[USER] - ';
                                    break;
                            }
                            $r = $tipo.$du[$a]['nombre'].', '.$du[$a]['apellido'];
                            echo '<a class="prestlink" href="/usuario/perfil/'.$du[$a]['id'].'">'.$r.'</a>';
                            $a++;
                        }
                    }else{
                        echo '<p>No s encuentran usuarios actualmente</p>';
                    }
                    ?>
                </div>
            </div>
        </div>
    </div>
