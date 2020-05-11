<div class="row">
    <div class="col s12">
        <div class="card blue-grey darken-1">
            <div class="card-content white-text">
                <span class="card-title">Tu Codgo PHP aqui:</span>
                <form id="formcode" action="/codeeditor" method="post">
                    <textarea style="height: 150px;color:white;" name="codigo" id="code" cols="30" rows="10"
                        ><?php echo $this->codigophp;?>
                    </textarea>
                    <button class="btn" type="submit" formtarget="resultcode" form="formcode">
                        <i class="fas fa-caret-square-right"></i> CORRER</button>
                    <button class="btn" type="reset">BORRAR</button>
                </form>
                <div class="card-action">
                    <p>Codigo Interpretado:</p>
                </div>
            </div>
            <iframe style="width: 100%;" name="resultcode"></iframe>
        </div>
    </div>
</div>