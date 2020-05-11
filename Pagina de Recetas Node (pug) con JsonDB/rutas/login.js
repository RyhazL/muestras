var epxx = require("express")
const db = require("../DB/DataBase")
const pug = require("pug");
var rt = epxx.Router()

rt.get("/",(p,r)=>{
    if(p.session.prm == "adm")
        r.redirect("/admin/editmenu")
        console.log(pug.renderFile("E:/Documentos/Paginas web/Pagina de Recetas/views/login.pug"));
        r.render("login")
});
rt.post("/",(p,r)=>{
    var dt = p.body.login
    stst = db.UserAuttf(dt.user,dt.pass)
    if(stst == 0){
        p.session.prm = "adm"
        r.redirect("/admin/editmenu")
    }
    else if(stst == 1)
        r.render("login",{r: "Usuario <strong>Incorrecto</strong>"})
    else if(stst == 2)
        r.render("login",{r: "Contraseña <strong>Incorrecta</strong>"})
})

module.exports = rt;