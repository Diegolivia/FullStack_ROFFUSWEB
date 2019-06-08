'use strict';

var canvas;
var globalState=states.draw;
var rooms=[];
function Start(){

    initCanvas();

    new Furniture("../img/muebles/sofa001.png");
    new Furniture("../img/muebles/silla001.png");
    new Furniture("../img/muebles/cama001.png");
    new Furniture("../img/muebles/mesa001.png");
    new Furniture("../img/muebles/alfombra001.png");

}
function initCanvas(){
    canvas=new fabric.Canvas('c',{
        width:window.innerWidth,
        height:window.innerHeight
    });

    

    fabric.Canvas.prototype.customiseControls({
        tl: {
            action: 'rotate',
            cursor: 'cow.png',
        },
        tr: {
            action: 'scale',
        },
        bl: {
            action: 'remove',
            cursor: 'pointer',
        },
        br: {
            action: 'moveUp',
            cursor: 'pointer',
        },
        mb: {
            action: 'moveDown',
            cursor: 'pointer',
        },
        mr: {
            action: function(e, target) {
                target.set({
                    left: 200,
                });
                canvas.renderAll();
            },
            cursor: 'pointer',
        },
        mt: {
            action: {
                'rotateByDegrees': 30,
            },
            cursor: 'pointer',
        },
        // only is hasRotatingPoint is not set to false
        mtr: {
            action: 'rotate',
            cursor: 'cow.png',
        },
    });

    fabric.Object.prototype.customiseCornerIcons({
        settings: {
            borderColor: 'black',
            cornerSize: 25,
            cornerShape: 'rect',
            cornerBackgroundColor: 'black',
            cornerPadding: 10
        },
        tl: {
            icon: '../img/icons/controls/rotate.svg'
        },
        tr: {
            icon: '../img/icons/controls/resize.svg'
        },
        bl: {
            icon: '../img/icons/controls/remove.svg'
        },
        br: {
            icon: '../img/icons/controls/up.svg'
        },
        mb: {
            icon: '../img/icons/controls/down.svg'
        },
        // only is hasRotatingPoint is not set to false
        mtr: {
            icon: '../img/icons/controls/rotate.svg'
        },
    }, function() {
        canvas.renderAll();
    } );

    fabric.Object.prototype.customiseCornerIcons({
        settings: {
            borderColor: '#0094dd',
            cornerSize: 25,
            cornerShape: 'rect',
            cornerBackgroundColor: 'black',
        },
        tl: {
            icon: '../img/icons/controls/rotate.svg',
        },
        tr: {
            icon: '../img/icons/controls/resize.svg',
        },
        ml: {
            icon: '//maxcdn.icons8.com/Share/icon/Logos//google_logo1600.png',
        },
        mr: {
            icon: '../img/icons/controls/diagonal-resize.svg',
        },
        // only is hasRotatingPoint is not set to false
        mtr: {
            icon: '../img/icons/controls/rotate.svg',
        },
    }, function() {
        canvas.renderAll();
    });
    fabric.Image.fromURL("../img/grid.jpg",function(img){
        canvas.setBackgroundImage(img,canvas.renderAll.bind(canvas), {
            scaleX: canvas.width / img.width,
            scaleY: canvas.width / img.width
         });
    });
    canvas.on("mouse:down",evt_canvas.mousedown);
    canvas.on("mouse:up",evt_canvas.mouseup);
    canvas.on("mouse:move",evt_canvas.mousemove);
    canvas.on("mouse:wheel",evt_canvas.mousewheel);
    canvas.on("object:moving",evt_canvas.objectmoving);

}
function createRoom(form){
    let tmp=new Room();
    tmp.init();
    tmp.addNodes(roomForms[form]);
    rooms.push(tmp);
}
window.addEventListener("load",Start);
