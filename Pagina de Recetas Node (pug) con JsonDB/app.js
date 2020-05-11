const exss = require("express")
var bp = require("body-parser")
var cookieSession = require("cookie-session")
var app = exss();

var home = require("./rutas/home")
var admin = require("./rutas/admin")
var recetas = require("./rutas/recetas")
var login = require("./rutas/login")

app.set("view engine","pug")
app.use(bp.urlencoded({extended: true}))
app.use(bp.json())
app.use(cookieSession({
    name: "sess",
    keys: ["asdasdasd","asdasdasdas"],
    maxAge: 24 * 60 * 60 * 1000
}))
app.use(exss.static("public"))
app.use("/",home)
app.use("/admin",admin)
app.use("/recetas",recetas)
app.use("/login",login)

module.exports = app
