var epxx = require("express")
const db = require("../DB/DataBase")
var rt = epxx.Router()

rt.use((p,r,next)=>{
    if(p.session.prm == "adm"){
        next();
    }
    else
        r.redirect("/")
})
rt.get("/",(p,r)=>{
    r.redirect("/admin/editmenu")
})
rt.get("/editmenu",(p,r)=>{
    var a = new Array()
    n_rct = db.Numero();
    for (let index = 1; index <= n_rct; index++) {
        var rect = db.ObtenerReceta(index)
        if(rect != null)
            a.push({name: rect.nombre, inx: index})
    }
    r.render("ap_editRecetas",{recetas: a})
})
rt.get("/d/:i([0-9]+)",(p,r)=>{
    r.render("borrar",{i: p.params.i,nombre: p.query.name})
})
rt.get("/d/:i([0-9]+)/true",(p,r)=>{
    db.EliminarReceta(p.params.i)
    r.redirect("/admin/editmenu")
})
rt.get("/n",(p,r)=>{
    r.render("ap_addReceta")
})
rt.post("/n",(p,r)=>{
    var data = p.body.f
    db.AgregarReceta(data.nombre,data.descripcion,data.ingredientes,data.pasos,data.imgurl)
    r.redirect("/admin/editmenu")
})

rt.post("/n_prev",(p,r)=>{
    var data = p.body.f
    r.render("recetaDisplay",{
        nombre: data.nombre, 
        descripcion: data.descripcion, 
        ingredientes: String(data.ingredientes).split(";"),
        pasos: String(data.pasos).split(";"),
        imgurl: data.imgurl
    })
})

module.exports = rt