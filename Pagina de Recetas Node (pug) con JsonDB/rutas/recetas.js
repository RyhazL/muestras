var epxx = require("express");
var db = require("../DB/DataBase");
var pug = require("pug");
var rt = epxx.Router();

rt.get("/",(p,r)=>{
    var busqueda = String(p.query.b)
    if(busqueda == "undefined")
        r.redirect("/recetas/indice/1")
    
})
rt.get("/ver/:n([0-9]+)",(p,r)=>{
    try{
        var resultado = db.ObtenerReceta(p.params.n);
        r.render("recetaDisplay",{
            nombre: resultado.nombre, 
            descripcion: resultado.descripcion, 
            ingredientes: String(resultado.ingredientes).split(";"),
            pasos: String(resultado.pasos).split(";"),
            imgurl: resultado.imgurl
        })
    }catch(e){
        r.redirect("/recetas/indice/1")
    }
});
rt.get("/indice/:n([0-9]+)",(p,r)=>{
    var a = new Array()
    n_rct = db.Numero();
    for (let index = 1; index <= n_rct; index++) {
        var rect = db.ObtenerReceta(index)
        if(rect != null)
            a.push({name: rect.nombre, inx: index})
    }
    r.render("recetas_list",{recetas : a},(err,html)=>{console.log(html)});
});
module.exports = rt;