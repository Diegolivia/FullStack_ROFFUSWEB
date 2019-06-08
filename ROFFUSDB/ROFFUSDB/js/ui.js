var sectionContruir={
    obj:null,
    opts:[],
    btnClose:null,
    init:function(){
        this.obj=document.querySelector("section.construir");
        this.btnClose=document.querySelector("section.construir .btn-cerrar");
        //this.opts=document.querySelectorAll("section.construir .box .btn-forma");
        this.btnClose.addEventListener("click",this.closed);
        for(var i in roomForms){
            let opt=document.createElement("div");
            opt.className="btn-forma";
            if(parseInt(i)/10>=1){
                opt.style.backgroundImage="url(../img/icons/rooms/icon" + i + ".png)";
            }else{
                opt.style.backgroundImage="url(../img/icons/rooms/icon0" + i + ".png)";
            }

            document.querySelector("section.construir .box .contenido").appendChild(opt);
            this.opts.push(opt);
            opt.addEventListener("click",this.createRoom);
        }
    },
    closed:function(){
        sectionContruir.obj.style.display="none";
    },
    createRoom:function(e){
        for(var i=0;i<sectionContruir.opts.length;i++){
            if(sectionContruir.opts[i]==e.target){
                createRoom(i+1);
            }
        }
    }
}
var sectionMainMenu={
    obj:null,
    opts:[],
    init:function(){
        this.obj=document.querySelector("section.barra");
        this.opts=document.querySelectorAll("section.barra .menu div");
        this.opts[0].addEventListener("click",this.optConstruir);
        this.opts[1].addEventListener("click",this.optFurniture)
    },
    optConstruir:function(){
        sectionContruir.obj.style.display="block";
    },
    optFurniture:function(){

    }
}

var sectionPanel={
    obj:null,
    opts:[],
    btnToggle:null,
    init:function(){
        this.obj=document.querySelector("section.panel");
        this.opts=document.querySelectorAll("section.panel .zona-contenedor");
        this.btnToggle=document.querySelector("section.panel .btn-toggle");

        this.btnToggle.addEventListener("click",this.btnToggleClicked);
        for(var i=0;i<this.opts.length;i++){
            this.opts[i].children[0].addEventListener("click",this.optClicked);
        }
        for(var i=0;i<this.opts.length;i++){
            this.opts[i].children[1].addEventListener("mouseover",this.subOptClicked);
        }
    },
    optClicked:function(e){
        e.target.parentNode.children[1].classList.toggle("closed");
    },
    subOptClicked:function(e){
        sectionSubPanel.showOptions(e.target.className);
    },
    btnToggleClicked:function(e){
        sectionPanel.obj.classList.toggle("toggle");
    }
}
var sectionSubPanel={
    obj:null,
    zonas:[],
    init:function(){
        this.obj=document.querySelector("section.subpanel");
        this.zonas=document.querySelectorAll("section.subpanel ul");
        this.obj.style.left=200 +"px";
        for(var i=0;i<this.zonas.length;i++){
            for(var j=0;j<this.zonas[i].children.length;j++){
                this.zonas[i].children[j].addEventListener("click",this.optClicked)
            }
        }
        document.querySelector(".canvas-container").addEventListener("click",this.windowClicked);
    },
    showOptions:function(className){
        let counter=0;
        for(let i=0;i<this.zonas.length;i++){
            if(this.zonas[i].id==className){
                
                this.zonas[i].style.display="block";
            }else{
                this.zonas[i].style.display="none";
                counter++;
            }
        }
        if(counter==this.zonas.length){
            this.obj.style.display="none";
        }else{
            this.obj.style.display="block";
        }
    },
    optClicked:function(){
        sectionSubPanel.obj.style.display="none";
        sectionPanel.obj.classList.toggle("toggle");
        sectionContenedor.obj.style.display="block";
    },
    windowClicked:function(){
        sectionSubPanel.obj.style.display="none";
    }
}
var sectionInfo={
    obj:null,
    fieldWidth:null,
    fieldHeight:null,
    fieldAngle:null,
    init:function(){
        this.obj=document.querySelector("section.info");
        this.fieldWidth=document.querySelector("section.info #ancho");
        this.fieldHeight=document.querySelector("section.info #alto");
        this.fieldAngle=document.querySelector("section.info #angulo");
    }
}
var sectionContenedor={
    obj:null,
    btnClose:null,
    init:function(){
        this.obj=document.querySelector("section.contenedor");
        this.btnClose=document.querySelector("section.contenedor .btn-cerrar");
        this.btnClose.addEventListener("click",this.btnCloseClicked);
    },
    btnCloseClicked:function(){
        sectionContenedor.obj.style.display="none";
    }
}
/**/ 
var sectionProject={
    obj:null,
    formsContainer:null,
    opts:[],
    btnCancel:null,
    btnCreate:null,
    init:function(){
        this.obj=document.querySelector("section.nuevo-proyecto");
        this.formsContainer=document.querySelector("section.nuevo-proyecto .formas-contenedor");
        this.btnCancel=document.querySelector("section.nuevo-proyecto .botones .btn-cancelar");
        this.btnCreate=document.querySelector("section.nuevo-proyecto .botones .btn-crear");
        this.btnCancel.addEventListener("click",this.btnCancelClicked);
        this.btnCreate.addEventListener("click",this.btnCreateClicked);
        BDPlantillas.list();

    },
    btnCancelClicked:function(){
        sectionProject.obj.style.display = "none";  
    },
    btnCreateClicked:function(){
        sectionProject.obj.style.display = "none";
    },
    fromDBShowList:function(list){

        for(var i=0;i<list.length;i++){
            let opt=document.createElement("div");
            opt.className="btn-forma";
            if(parseInt(list[i].CPlantilla)/10>=1){
                opt.style.backgroundImage="url(img/icons/rooms/icon" + list[i].CPlantilla+ ".png)";
            }else{
                opt.style.backgroundImage="url(img/icons/rooms/icon0" + list[i].CPlantilla + ".png)";
            }

            document.querySelector("section.nuevo-proyecto .box .formas-contenedor").appendChild(opt);
            this.opts.push(opt);
            opt.addEventListener("click",this.plantillaClicked);
        }
    },
    fromDBCreateRoom:function(nodos){
        var json = nodos;

        var newJson = json.replace(/([a-zA-Z0-9]+?):/g, '"$1":');
        newJson = newJson.replace(/'/g, '"');

        var data = JSON.parse(newJson);
        console.log(data);
        /**/ 
        let tmp=new Room();
        tmp.init();
        tmp.addNodes(data);
        rooms.push(tmp);
    },
    plantillaClicked:function(e){
        for(var i=0;i<sectionProject.opts.length;i++){
            console.log(e.target);
            console.log(sectionProject.opts[i]);
            if(sectionProject.opts[i]==e.target){
                BDPlantillas.findById(i+1);
            }
        }
    }

    
}

/**/ 
function loaded(){
    sectionContruir.init();
    sectionMainMenu.init();
    sectionSubPanel.init();
    sectionPanel.init();
    sectionInfo.init();
    sectionContenedor.init();
    sectionProject.init();
}
window.addEventListener("load",loaded);