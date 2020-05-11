<!DOCTYPE html>
    <html>
        <head>
            <meta charset="UTF-8">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
            <meta http-equiv="X-UA-Compatible" content="ie=edge">
            <title>LABORATOROI VIRTUAL</title>
            <link rel="stylesheet" href="/public/css/materialize.css">
            <link rel="stylesheet" href="/public/css/style.css">
            <link rel="stylesheet" href="/public/css/icons.css">
            <script src="/public/js/materialize.js"></script>
            <script src="/public/js/init.js"></script>
        </head>
            <body>
        <?php if(!$this->ispreview){
            require 'vistas/layout/header.php';
            echo '<div class="realbody"><div class="mainBox mbfixed">';
        }
        ?>
                <div class="row">
                    <div class="col s12">
                        <h4><?php echo $this->titulo;?></h4>
                    </div>
                    <div class="col s12">
                        <div class="row"><?php 

                        $cont = explode('<phpcode>',$this->contenido);
                        $division = count($cont);
                        if($division > 1){
                            if(($division % 2) == 1){
                                $inx = 0;
                                while($inx < $division){
                                    if(($inx % 2) == 1){
                                        $this->codigophp = $cont[$inx];
                                        require_once 'vistas/codeeditor/index.php';
                                    }else{
                                        echo $cont[$inx];
                                    }
                                    $inx++;
                                }
                            }else{
                                echo 'ERROR: Cierra cada comando "phpcode" que tengas con otro comando';
                            }
                        }else{
                            echo $this->contenido;;
                        }
                        
                        ?></div>
                    </div>
                    <div class="col s12">
                        <?php echo $this->footer?>
                    </div>
            <?php if(!$this->ispreview) echo '</div></div></div>';?>
        </body>
    </html>
