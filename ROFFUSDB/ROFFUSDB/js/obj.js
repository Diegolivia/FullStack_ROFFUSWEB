var RoomNode=function(x,y){ 
        this.x=x;
        this.y=y;
        this.obj;  

    this.init=function(){
        this.obj=new fabric.Circle({
            left:this.x,
            top:this.y,
            radius:6,
            stroke:'blue',
            fill:'transparent'
        })
        this.obj.handler=true;
        this.obj["hasControls"]=false;
        canvas.add(this.obj);
    };
    this.getCoord=function(){
        return new fabric.Point(this.obj.left+this.obj.radius,this.obj.top+this.obj.radius);
    }
    this.init();
}
var Room=function(){
    this.nodes=[];
    this.path;
    this.pathId=Math.round(Math.random()*100);
    this.background;
    this.pattern;
    this.lastPoint=new fabric.Point({x:0,y:0});
    let self=this;
    this.init=function(){
        fabric.Image.fromURL('../img/floor.jpg',function(img){
            img.scaleToWidth(100);
            var patternSourceCanvas = new fabric.StaticCanvas();
            patternSourceCanvas.add(img);
            patternSourceCanvas.renderAll();
            self.background=img;
            self.pattern=new fabric.Pattern({
                source: function() {
                    patternSourceCanvas.setDimensions({
                      width: img.getScaledWidth(),
                      height: img.getScaledHeight()
                    });
                    patternSourceCanvas.renderAll();
                    return patternSourceCanvas.getElement();
                  },
                repeat:'repeat'
            })
            self.drawPath();
        })

        this.path=new fabric.Polygon([],{fill:self.pattern,objectCaching:false});
        this.path.id=this.pathId;
        this.path.on("mouseup",this.onUp)
        this.path.on("mousedown",this.onDown)
        this.path.on("moving",this.onMoving);
        canvas.add(this.path);
        this.path.moveTo(0);
        //this.path["selectable"]=false;

    }
    this.addNodes=function(points){
        for(var i=0;i<points.length;i++){
            this.addNode(points[i].x,points[i].y);
        }
    }
    this.addNode=function(x,y){
        if(globalState==states.draw){
            let node=new RoomNode(x,y);
            node.obj.on("moving",this.handlerMoved);
            this.nodes.push(node);
            this.drawPath();
        }
    }
    this.showNodes=function(foo){
        for(var i=0;i<this.nodes.length;i++){
            if(foo){
                this.nodes[i].opacity=0;
            }else{
                this.nodes[i].opacity=1;
            }

        }
    }
    this.drawPath=function(){
            var points=[]
            points.push({x:this.nodes[0].getCoord().x,y:this.nodes[0].getCoord().y});
            for(let i=1;i<this.nodes.length;i++){
                points.push({x:this.nodes[i].getCoord().x,y:this.nodes[i].getCoord().y});
            }
            //this.path.points=points;
            //this.path.fill=pattern;
            this.path=new fabric.Polygon(points,{fill:self.pattern,objectCaching:false})
            this.path.id=this.pathId;
            ;
            this.path["hasControls"]=false;
            let allObjects=canvas.getObjects();
            for(var i=0;i<allObjects.length;i++){
                if(allObjects[i].id!= undefined && allObjects[i].id==this.pathId){
                    canvas.remove(canvas.item(i));
                    canvas.insertAt(this.path,i,false);
                    break;
                }
            }

            this.path.on("mouseup",this.onUp)
            this.path.on("mousedown",this.onDown)
            this.path.on("moving",this.onMoving);
            canvas.renderAll();
    }
    this.onUp=function(){
    }
    this.onMoving=function(){
        let dx=self.path.get("left")-self.lastPoint.x;
        let dy=self.path.get("top")-self.lastPoint.y;
        for(var i=0;i<self.nodes.length;i++){
            let nodeObj=self.nodes[i].obj;
            nodeObj.set("left",nodeObj.get("left")+dx);
            nodeObj.set("top",nodeObj.get("top")+dy);   
            nodeObj.setCoords();
        }
        self.lastPoint.x=self.path.get("left");
        self.lastPoint.y=self.path.get("top");
        canvas.requestRenderAll();
    }
    this.onDown=function(){
        self.lastPoint.x=self.path.get("left");
        self.lastPoint.y=self.path.get("top");
    }
    this.handlerMoved=function(){
        self.drawPath();
    }
}
var Furniture=function(url,ancho=0,alto=0){
    this.obj;
    this.imgUrl=url;    
    this.width=ancho;
    this.height=alto;
    let self=this;
    this.init=function(){
        fabric.Image.fromURL(this.imgUrl,function(img){
            self.obj=img;
            img.on("selected",self.isSelected)
            img.on("modified",self.isSelected)
            if(self.width!=0 && self.height!=0){
                img.set("scaleX",self.width/img.get("width"));
                img.set("scaleY",self.height/img.get("height"));
            }
            canvas.add(img);
        });
        
    }
    this.isSelected=function(){
        sectionInfo.fieldWidth.value=self.obj.getScaledWidth("width");
        sectionInfo.fieldHeight.value=self.obj.getScaledHeight("height");
        sectionInfo.fieldAngle.value=self.obj.get("angle");
    }
    this.init();
}
var states={
    normal:0,
    draw:1,
    pause:2
}
var mouse={
    x:0,
    y:0,
    clicked:false
}

var roomForms={
    "1":[{x:500,y:500},{x:800,y:500},{x:800,y:800},{x:500,y:800}],
    "2":[{x:0,y:0},{x:300,y:0},{x:300,y:600},{x:0,y:600}],
    "3":[{x:0,y:0},{x:200,y:0},{x:200,y:200},{x:400,y:200},{x:400,y:400},{x:0,y:400}],
    "4":[{x:0,y:200},{x:200,y:200},{x:200,y:0},{x:400,y:0},{x:400,y:400},{x:0,y:400}],
    "5":[{x:0,y:0},{x:400,y:0},{x:400,y:200},{x:200,y:200},{x:200,y:400},{x:0,y:400}],
    "6":[{x:0,y:0},{x:400,y:0},{x:400,y:400},{x:200,y:400},{x:200,y:200},{x:0,y:200}],
    "7":[{x:0,y:0},{x:250,y:0},{x:400,y:150},{x:400,y:400},{x:0,y:400}],
    "8":[{x:0,y:150},{x:150,y:0},{x:400,y:0},{x:400,y:400},{x:0,y:400}],
    "9":[{x:0,y:0},{x:400,y:0},{x:400,y:250},{x:250,y:400},{x:0,y:400}],
    "10":[{x:0,y:0},{x:400,y:0},{x:400,y:400},{x:150,y:400},{x:0,y:250}],  
}