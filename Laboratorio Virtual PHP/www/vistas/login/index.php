
<?php require 'vistas/layout/header.php' ?>
<div class="realbody">
    <form class="login mainBox" action="/login/authin" method="post">
        <h4>Inicia Sesion</h4>
        <input type="text" name="user" placeholder="Coreo">
        <input type="password" name="pass" placeholder="Contraseña">
        <input type="submit" value="Entrar">
        <?php if(isset($this->AuthErr)) echo '<h6>'.$this->AuthErr.'</h6>'; ?>
        <a class="prestlink" style="width: 102%;margin: 0;" href="/singin">REGISTRARCE</a>
    </form>
</div>