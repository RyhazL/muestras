
<?php require 'vistas/layout/header.php' ?>
<div class="realbody">
    <form class="login mainBox" action="/singin/auth" method="post">
        <h4>Registrate</h4>
        <input type="text" name="name" placeholder="Nombre">
        <input type="text" name="lastname" placeholder="Apellido">
        <input type="email" name="correo" placeholder="correo@example.com">
        <input type="password" name="clave" placeholder="Contraseña">
        <input type="submit" value="REGISTRARCE">
        <?php if(isset($this->AuthErr)) echo '<h6>'.$this->AuthErr.'</h6>'; ?>
    </form>
</div>