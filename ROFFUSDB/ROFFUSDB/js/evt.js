var evt_canvas={
    mousedown:function(opt){
        var evt = opt.e;
        if (evt.altKey === true) {
          this.isDragging = true;
          this.selection = false;
          this.lastPosX = evt.clientX;
          this.lastPosY = evt.clientY;
        }
        if(canvas.getActiveObject()==null){
        
            //room.addNode(opt.e.clientX,opt.e.clientY);  
        }
        //ocultar panel info
        let activeObject=canvas.getActiveObject();
        if(activeObject==null){
            sectionInfo.obj.style.display="none";
        }else{
            sectionInfo.obj.style.display="block";
        }
    },
    mouseup:function(opt){
        this.isDragging = false;
        this.selection = true;
    },
    mousemove:function(opt){
        if (this.isDragging) {
            var e = opt.e;
            this.viewportTransform[4] += e.clientX - this.lastPosX;
            this.viewportTransform[5] += e.clientY - this.lastPosY;
            this.requestRenderAll();
            this.lastPosX = e.clientX;
            this.lastPosY = e.clientY;
        }
    },
    mousewheel:function(opt){
        var delta = -opt.e.deltaY;
        var pointer = canvas.getPointer(opt.e);
        var zoom = canvas.getZoom();
        zoom = zoom + delta/500;
        if (zoom > 20) zoom = 20;
        if (zoom < 0.01) zoom = 0.01;
        canvas.zoomToPoint({ x: opt.e.offsetX, y: opt.e.offsetY }, zoom);
        opt.e.preventDefault();
        opt.e.stopPropagation();
        this.requestRenderAll();
    },
    objectmoving:function(opt){

    }
}
