<?php require 'vistas/layout/header.php' ?>
    <div class="realbody">
        <div class="mainBox mbfixed">
            <div class="row">
                <div class="col s12 m12">
                    <div class="card horizontal">
                        <div class="card-image">
                            <?php
                            if($this->tipoperfil == 4){
                                echo '<img src="http://localhost/public/img/fotoadmin.png">';
                                echo '<span class="card-title">'.$this->nombre.' [ADMINSTRADOR] </span>';
                            }else{
                                echo '<img src="http://localhost/public/img/fotoperfil.png">';
                                echo '<span class="card-title">'.$this->nombre.'</span>';
                            }
                            ?>
                        </div>
                        <div class="card-content">
                            <h5>ID:</h5>
                            <p><?php echo $this->idperfil;?></p>
                            <h5>Descripcion:</h5>
                            <p>Mi descripcion esta vacia, talvez algun dia la rellene.</p>
                        </div>
                        <div class="card-action">
                            <h5>Redes sociales: </h5>
                            <a  href="#">
                                <i class="fab fa-google-plus-square fa-3x"></i>
                            </a>
                            <a  href="#">
                                <i class="fab fa-twitter-square fa-3x"></i>
                            </a>
                             <a href="#">
                                <i class="fab fa-facebook fa-3x"></i>
                            </a>
                        </div>
                    </div>
                    <h5 class="center ">Posts publicados por mi:</h5>
                    <?php
                    $publicaciones = $this->publi;
                    $a = 0;
                    echo '<div class="col s12">';
                    echo '<div class="row">';
                    if(is_array($publicaciones) && !empty($publicaciones)){
                        
                        $inx = count($publicaciones);

                        $eselusuario = $this->logged && ($this->id == $this->idperfil);
                        $admin = $this->tipo == 4;
                        while ($a < $inx) {
                            $r = $publicaciones[$a]['nombre'];
                            if($admin || $eselusuario){
                            echo '<div class="col s10"><a class="prestlink" href="/publicaciones/ver/'.
                            $publicaciones[$a]['id'].'">'.$r.'</a></div>';
                            echo '<div class="col s1">';
                                echo '<a href="/publicaciones/editar/'.
                                $publicaciones[$a]['id'].'" data-position="top" data-tooltip="Editar Publicacion" 
                                class="tooltipped"><i class="fas fa-edit fa-2x"></i><a/>';
                            echo '</div>';
                            echo '<div class="col s1">';
                                echo '<a href="/publicaciones/eliminar/'.
                                $publicaciones[$a]['id'].'" data-position="top" data-tooltip="Borrar Publicacion" 
                                class="tooltipped"><i class="fas fa-window-close fa-2x"></i><a/>';
                            echo '</div>';
                            }else{
                                echo '<div class="col s12"><a class="prestlink" href="/publicaciones/ver/'.
                                $publicaciones[$a]['id'].'">'.$r.'</a></div>'; 
                            }
                            $a++;
                        }
                    }
                    if($a == 0){
                        echo '<p class="col s12 center">No hay Publicaciones actualmente de este usuario</p>';
                    }
                    echo '</div></div>';
                    ?>
                </div>
            </div>
        </div>
    </div>