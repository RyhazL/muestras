<?php require 'vistas/layout/header.php' ?>
    <div class="realbody">
        <div class="mainBox mbfixed">
            <div class="row">
                <h4 class="center">PUBLICAR:</h4>
                    <form class="col s12" action="http://localhost/publicaciones/postdata" method="post">
                        <div class="row">
                            <div class="input-field col s12">
                                <input type="text" name="newpost[titulo]" id="nombrepost">
                                <label for="nombrepost">Titulo de la Publicacion</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="input-field col s12">
                                <textarea style="height: 300px;" name="newpost[contenido]" id="contenido" cols="30" rows="10"></textarea>
                                <label for="nombrepost">Contenido</label>
                            </div>
                        </div>
                            <button class="btn waves-effect waves-light blue darken-4" type="submit" formtarget="resultado" 
                            formaction="http://localhost/publicaciones/postdata/preview">PREVIEW</button>
                            <button class="btn waves-effect waves-light blue darken-4" type="submit">PUBLICAR</button>
                        </div>
                    </form>
                <iframe style="width: 100%; height: 500px" name="resultado"></iframe>
            </div>
        </div>
    </div>
