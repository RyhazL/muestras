<?php require 'vistas/layout/header.php' ?>
    <div class="realbody">
        <div class="mainBox mbfixed">
            <div class="row"><h2 class="col s12 center">Publicaciones de nuestros usuarios:</h2></div>
            
            <div class="row">
                <div class="col s10 push-s1">
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
            </div>
            <div class="row">
                <div class="col s12">
                    <ul class="pagination">
                        <?php
                        $num = $this->numpag;
                        $p = $this->pagactual;
                        if(($p - 1) == 0){
                            echo '<li class="disabled"><a href="#"><i class="fas fa-arrow-left"></i></a></li>';
                        }else{
                            echo '<li class="waves-effect"><a href="/publicaciones/'.($p-1).'"><i class="fas fa-arrow-left"></i></a></li>';
                        }
                        for ($i=1; $i <= $num; $i++) { 
                            if($i == $p){
                                echo '<li class="active blue darken-4"><a href="/publicaciones/'.$i.'">'.$i.'</a></li>';
                            }else{
                                echo '<li class="waves-effect"><a href="/publicaciones/'.$i.'">'.$i.'</a></li>';
                            }
                        }
                        if(($p + 1) > $num){
                            echo '<li class="disabled"><a href="#"><i class="fas fa-arrow-right"></i></a></li>';
                        }else{
                            echo '<li class="waves-effect"><a href="/publicaciones/'.($p+1).'"><i class="fas fa-arrow-right"></i></a></li>';
                        }
                        ?>
                    </ul>
                </div>
            </div>
        </div>
    </div>