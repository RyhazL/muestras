var JasonDB = require("node-json-db")

var adminsDB = new JasonDB(__dirname + "/Admins.json",true,false)
var recetasDB = new JasonDB(__dirname+ "/Recetas.json",true,true)
const Receta = {
    nombre : "", 
    descripcion : "", 
    ingredientes : "",
    pasos : "",
    imgurl : ""
}
function UserAuttf (usuario = "",contrasna = ""){
    var userBool = Boolean(false)
    var passBool = Boolean(false)
    v = adminsDB.getData("/")
    if(usuario == v["user"])
        userBool = true
    if(contrasna == v["pass"])
        passBool = true
    if(userBool == true && passBool == true)
        return 0
    else if (userBool == false)
        return 1
    else if (passBool == false)
        return 2
}
function BuscarReceta(valor = "", cuantos = 8){
    var data = recetasDB.getData("/")
    var succes = Array(cuantos)
    let n = 0
    if(data["index"] <= 0)
        return null;
    var recetas = Array(data["recetas"])
    for (let i = 0; i < recetas.length; i++) {
        var rct = array[i]
        var frct = String(rct["nombre"])
        frct.replace("-"," ")
        if(frct.includes(valor,0))
            succes[n] = i; n +=1
        if(n == cuantos)
            break
    }
    return succes;
}
function Numero(){
    return recetasDB.getData("/recetas").length
}
function ObtenerReceta(indice){
    indice--;
    var a = recetasDB.getData("/recetas[" + indice +"]")
    if(a == null)
        return null;
    var k = Receta
    k.nombre = a["nombre"]
    k.descripcion = a["descripcion"]
    k.ingredientes = a["ingredientes"]
    k.pasos = a["pasos"]
    k.imgurl = a["imgurl"]
    return k
}
function AgregarReceta(nombre = "", descripcion = "", ingredientes = "",pasos ="",imgurl = ""){
    var dbdata = recetasDB.getData("/")
    var inx = dbdata["index"]
    var recetasArray = dbdata["recetas"]
    inx += 1;
    var sameindx = true;
    for (let index = 0; index < recetasArray.length; index++) {
        if(recetasArray[index] == null){
        inx = index
        console.log("NULL encontrado, salvando en index: " + inx)
        sameindx = false;
        break;
        }
    }
    data = {nombre,descripcion,ingredientes,pasos,imgurl}
    recetasDB.push("/recetas[" + inx +"]", data)
    if(sameindx)
        recetasDB.push("/index",inx)
}
function ActualizarReceta(indice,nombre = "", descripcion = "", ingredientes = "",pasos ="",imgurl = ""){
    data = {nombre,descripcion,ingredientes,pasos,imgurl}
    recetasDB.push("/recetas[" + indice +"]", data)
}
function EliminarReceta(indice){
    indice--
    recetasDB.delete("/recetas[" + indice +"]")
    indice --
    recetasDB.push("/index",indice)
}


module.exports = {
    UserAuttf, 
    AgregarReceta, 
    BuscarReceta, 
    ObtenerReceta, 
    ActualizarReceta,
    Numero,
    EliminarReceta, 
    Receta
}