var epxx = require("express");
var rt = epxx.Router();

rt.get("/",(p,r)=>{
    if(p.session.prm != "adm")
        p.session.prm = "usr";
    if(p.query.logout == "true" && p.session.prm == "adm")
        p.session.prm = "usr";
    r.render("main");
});
module.exports = rt;

