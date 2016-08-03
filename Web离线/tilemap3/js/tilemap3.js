var browser = "";
var myFocusRow = -1; //中心行
var myFocusCol = -1; //中心列
var offsetX = -1; //中心列偏移像素值X
var offsetY = -1; //中心行偏移像素值Y
var lines = new Array(); //保存线条的数组

/**地图级别*/
var mapLevel = 7;
var containerLeft = 0;
var containerTop = 0;
var isDblClickImg = false;

var EARTHRADIUS = 6370996.81;
var MCBAND = [12890594.86, 8362377.87, 5591021, 3481989.83,
  1678043.12, 0];
var LLBAND = [75, 60, 45, 30, 15, 0];
var MC2LL = [
  [1.410526172116255e-8, 0.00000898305509648872,
    -1.9939833816331, 200.9824383106796,
    -187.2403703815547, 91.6087516669843,
    -23.38765649603339, 2.57121317296198,
    -0.03801003308653, 17337981.2],
  [-7.435856389565537e-9, 0.000008983055097726239,
    -0.78625201886289, 96.32687599759846,
    -1.85204757529826, -59.36935905485877,
    47.40033549296737, -16.50741931063887,
    2.28786674699375, 10260144.86],
  [-3.030883460898826e-8, 0.00000898305509983578,
    0.30071316287616, 59.74293618442277,
    7.357984074871, -25.38371002664745,
    13.45380521110908, -3.29883767235584,
    0.32710905363475, 6856817.37],
  [-1.981981304930552e-8, 0.000008983055099779535,
    0.03278182852591, 40.31678527705744,
    0.65659298677277, -4.44255534477492,
    0.85341911805263, 0.12923347998204,
    -0.04625736007561, 4482777.06],
  [3.09191371068437e-9, 0.000008983055096812155,
    0.00006995724062, 23.10934304144901,
    -0.00023663490511, -0.6321817810242,
    -0.00663494467273, 0.03430082397953,
    -0.00466043876332, 2555164.4],
  [2.890871144776878e-9, 0.000008983055095805407,
    -3.068298e-8, 7.47137025468032,
    -0.00000353937994, -0.02145144861037,
    -0.00001234426596, 0.00010322952773,
    -0.00000323890364, 826088.5]];
var LL2MC = [
  [-0.0015702102444, 111320.7020616939,
    1704480524535203, -10338987376042340,
    26112667856603880, -35149669176653700,
    26595700718403920, -10725012454188240,
    1800819912950474, 82.5],
  [0.0008277824516172526, 111320.7020463578,
    647795574.6671607, -4082003173.641316,
    10774905663.51142, -15171875531.51559,
    12053065338.62167, -5124939663.577472,
    913311935.9512032, 67.5],
  [0.00337398766765, 111320.7020202162,
    4481351.045890365, -23393751.19931662,
    79682215.47186455, -115964993.2797253,
    97236711.15602145, -43661946.33752821,
    8477230.501135234, 52.5],
  [0.00220636496208, 111320.7020209128,
    51751.86112841131, 3796837.749470245,
    992013.7397791013, -1221952.21711287,
    1340652.697009075, -620943.6990984312,
    144416.9293806241, 37.5],
  [-0.0003441963504368392, 111320.7020576856,
    278.2353980772752, 2485758.690035394,
    6070.750963243378, 54821.18345352118,
    9540.606633304236, -2710.55326746645,
    1405.483844121726, 22.5],
  [-0.0003218135878613132, 111320.7020701615,
    0.00369383431289, 823725.6402795718,
    0.46104986909093, 2351.343141331292,
    1.58060784298199, 8.77738589078284,
    0.37238884252424, 7.45]];

/**
 * 通过经纬度转化为块坐标
 * @param x
 * @param y
 */
function convertLL2BlockXy(x, y) {
    var t = convertLL2MC(x, y);
    var x1 = parseInt(t[0] * Math.pow(2, mapLevel - 18) / 256);
    var y1 = parseInt(t[1] * Math.pow(2, mapLevel - 18) / 256);
    return [x1, y1];
}

/**
 * 将行列块坐标转换成经纬度
 * @param x
 * @param y
 */
function convertBlockXy2LL(x, y) {
    var mx = (x * 256 + 0.0) / Math.pow(2, mapLevel - 18);
    var my = (y * 256 + 0.0) / Math.pow(2, mapLevel - 18);
    return convertMC2LL(mx, my);
}

/**
 * 将墨卡多转为经纬度
 * @param cB
 * @returns
 */
function convertMC2LL(x, y) {
    var tempArray;
    for (var i = 0; i < MCBAND.length; i++) {
        if (y >= MCBAND[i]) {
            tempArray = MC2LL[i];
            break;
        }
    }
    return convertor(x, y, tempArray);
}

/**
 * 将经纬度转化为墨卡多
 * @param x
 * @param y
 * @returns {b3}
 */
function convertLL2MC(x, y) {
    var array;
    for (var i = 0; i < LLBAND.length; i++) {
        if (y >= LLBAND[i]) {
            array = LL2MC[i];
            break;
        }
    }
    return convertor(x, y, array);
}

function convertor(x, y, array) {
    x = array[0] + array[1] * Math.abs(x);
    var cB = y / array[9];
    var cE = array[2] + array[3] * cB + array[4] * cB * cB + array[5] * cB * cB * cB + array[6] * cB * cB * cB * cB + array[7] * cB * cB * cB * cB * cB + array[8] * cB * cB * cB * cB * cB * cB;
    return [x, cE];
}

/**
 * 获得指定经度在归属列上的偏移值(单位像素)，返回值范围0-255像素。
 * @param longitude
 * @param column:即longitude所在的列。如果column>0时有效(此函数将不用计算longitude所在的列)
 * @returns
 */
function getOffsetX(longitude, latitude, column) {
    var temp = convertLL2BlockXy(longitude, latitude);
    if (column <= 0) {
        column = temp[0];
    }
    var maxLongitude = convertBlockXy2LL(column + 1, temp[1])[0];
    var minLongitude = convertBlockXy2LL(column, temp[1])[0];

    if (maxLongitude == minLongitude) {
        return 0;
    }
    return parseInt((longitude - minLongitude) * 256 / (maxLongitude - minLongitude));
}

/**
 * 获得指定纬度在归属行上的偏移值(单位像素)，返回值范围0-255像素。
 * @param latitude
 * @param row:此行是通过latitude算出来的,即latitude所在的行。如果row>0时有效(此函数将不用计算latitude所在的行)
 * @returns {Number}
 */
function getOffsetY(longitude, latitude, row) {
    var temp = convertLL2BlockXy(longitude, latitude);
    if (row <= 0) {
        row = temp[1];
    }

    var maxLatitude = convertBlockXy2LL(temp[0], row + 1)[1];
    var minLatitude = convertBlockXy2LL(temp[0], row)[1];

    if (maxLatitude == minLatitude) {
        return 0;
    }
    return parseInt((maxLatitude - latitude) * 256 / (maxLatitude - minLatitude));
}

/**
 * 获得得点击的经纬度,返回的是一个两个元素的一维数组
 * @param longitude
 * @param latitude
 * @param e
 * @returns {Number}
 */
function getClickLongLati(e) {
    var distanceX = e.clientX - $("#r" + myFocusRow + "c" + myFocusCol).offset().left;
    var clickCol = myFocusCol + parseInt(distanceX / 256);
    var clickOffsetX = distanceX % 256;

    var distanceY = $("#r" + myFocusRow + "c" + myFocusCol).offset().top + 256 - e.clientY;
    var clickRow = myFocusRow + parseInt(distanceY / 256);
    var clickOffsetY = distanceY % 256;

    var min = convertBlockXy2LL(clickCol, clickRow);
    var max = convertBlockXy2LL(clickCol + 1, clickRow + 1);

    var array = new Array();
    array[0] = min[0] + (max[0] - min[0]) * clickOffsetX / 256;
    array[1] = min[1] + (max[1] - min[1]) * clickOffsetY / 256;
    return array;
}

/**
 * 右击鼠标，缩小地图
 * @param t
 * @param e
 */
function zoomOutMap(e) {
    //alert(mapLevel);
    if (mapLevel <= 10) {
        return;
    }
    var temp = getClickLongLati(e);
    mapLevel--;
    locateMap(temp[0], temp[1]);
}

/**
 * 鼠标双击，放大地图
 * @param t
 * @param e
 */
function zoomInMap(e) {
    //alert(mapLevel);
    if (mapLevel >= 16) {
        return;
    }
    var temp = getClickLongLati(e);
    mapLevel++;
    locateMap(temp[0], temp[1]);
}

var dragX = -1;
var dragY = -1;
var startX = -1;
var startY = -1;

/**
 * 点击地图，准备拖动
 * @param e
 */
function startDragMap(e) {
    //closeMenu();
    //closeRightMenu();
    dragX = e.clientX;
    dragY = e.clientY;
    startX = dragX;
    startY = dragY;
    containerLeft = parseInt($("#mapContainer").css("left"));
    containerTop = parseInt($("#mapContainer").css("top"));
    $("#mapContainer").css("cursor", "pointer");
    //stopBubble(e);
}

/**
 * 释放鼠标或移出地图视图区域，放弃拖动地图
 * @param e
 */
function endDragMap(e) {
    dragMap(e);
    if (startX < 0) {
        return;
    }
    offsetX = offsetX + e.clientX - startX;
    offsetY = offsetY + e.clientY - startY;
    dragX = -1;
    startX = -1;
    myFocusRow = myFocusRow + parseInt(offsetY / 256);
    offsetY = offsetY % 256;
    myFocusCol = myFocusCol - parseInt(offsetX / 256);
    offsetX = offsetX % 256;
    var cols = Math.ceil($("#panel").innerWidth() / 512 + 3);
    var rows = Math.ceil($("#panel").innerHeight() / 512 + 3);
    var left = parseInt($("#r" + myFocusRow + "c" + myFocusCol).css("left"));
    var top = parseInt($("#r" + myFocusRow + "c" + myFocusCol).css("top"));
    var fileName;
    var style;
    var id = null;
    for (var i = myFocusRow + rows; i >= myFocusRow - rows; i--) {
        for (var j = myFocusCol - cols; j <= myFocusCol + cols; j++) {
            id = "r" + i + "c" + j;
            if ($("#" + id).size() == 0) {
                fileName = mapLevel + "/" + i + "/" + j + ".png";
                style = "left:" + (left - (myFocusCol - j) * 256) + "px;top:" + (top + (myFocusRow - i) * 256) + "px;background-image:url(../img/baidu/" + fileName + ")";
                $("#mapContainer").append("<div id='" + id + "' style='" + style + "'></div>");
            }
        }
    }

    //画板及连线
    if (browser != "ie") {
        var canvas = $("#canvasId");
        canvas.css("top", (-parseInt($("#mapContainer").css("top")) - 300) + "px");
        canvas.css("left", (-parseInt($("#mapContainer").css("left")) - 400) + "px");
        canvas = document.getElementById("canvasId");
        canvas.height = $("#panel").height() + 600;
        canvas.width = $("#panel").width() + 800;
    } else {
        for (i = 0; i < lines.length;) {
            $("#" + lines[i].id).remove();
            i++;
        }
    }

    for (i = 0; i < lines.length;) {
        drawLine(lines[i].srcLongitude, lines[i].srcLatitude, lines[i].destLongitude, lines[i].destLatitude, lines[i].color, lines[i].id);
        i++;
    }

    $("#mapContainer").css("cursor", "default");
}

/**
 * 拖动地图
 * @param t
 * @param e
 */
function dragMap(e) {
    if (dragX < 0) {
        //winMove(e);
        return;
    }
    containerLeft = containerLeft + e.clientX - dragX;
    containerTop = containerTop + e.clientY - dragY;
    $("#mapContainer").css("left", containerLeft + "px");
    $("#mapContainer").css("top", containerTop + "px");
    dragX = e.clientX;
    dragY = e.clientY;
}

/**
 * (参考原点为mapContainer)根据经度，获得瓦片对应的样式left数值，单位px.调用前必须先定位好地图即locateMap
 * @param longitude
 */
function getLeft(longitude, latitude) {
    var col = convertLL2BlockXy(longitude, latitude)[0];
    var id = $(".firstTile").attr("id");
    var firstCol = parseInt(id.substring(id.indexOf('c') + 1));
    return (col - firstCol) * 256 + getOffsetX(longitude, latitude, col);
}

/**
 * (参考原点为mapContainer)根据纬度，获得瓦片对应的样式top数值，单位px.调用前必须先定位好地图即locateMap
 * @param latitude
 * @returns
 */
function getTop(longitude, latitude) {
    var row = convertLL2BlockXy(longitude, latitude)[1];
    var id = $(".firstTile").attr("id");
    var firstRow = parseInt(id.substring(1, id.indexOf('c')));
    return (firstRow - row) * 256 + getOffsetY(longitude, latitude, row);
}

/**
 * 画一条线，此方法为外部调用。
 * @param id:线的ID
 * @param srcLongitude：起始经度
 * @param srcLatitude：起始纬度
 * @param destLongitude：终止经度
 * @param destLatitude：终止纬度
 * @param color：线的颜色
 */
function line(id, srcLongitude, srcLatitude, destLongitude, destLatitude, color) { //alert("id="+id+"  color="+color);
    var line = new Object();
    line.id = id;
    line.srcLongitude = srcLongitude;
    line.srcLatitude = srcLatitude;
    line.destLongitude = destLongitude;
    line.destLatitude = destLatitude;
    line.color = color;
    lines[lines.length] = line;
    drawLine(srcLongitude, srcLatitude, destLongitude, destLatitude, color, id);
}

/**
 * 删除连接,其线的ID为id
 * @param id
 */
function delLine(id) {
    var line = null;
    for (var i = 0; i < lines.length; i++) {
        line = lines[i];
        if (line.id == id) {
            lines.splice(i, 1);
            break;
        }
    }
    if (line != null) {
        if (browser == "ie") {
            $("#" + id).remove();
        } else {
            //重绘
            $("#canvasId").remove();
            $("#mapContainer").append("<canvas id='canvasId'></canvas>");
            var canvas = $("#canvasId");
            canvas.css("top", (-parseInt($("#mapContainer").css("top")) - 300) + "px");
            canvas.css("left", (-parseInt($("#mapContainer").css("left")) - 400) + "px");
            canvas = document.getElementById("canvasId");
            canvas.height = $("#panel").height() + 600;
            canvas.width = $("#panel").width() + 800;
            for (i = 0; i < lines.length; i++) {
                drawLine(lines[i].srcLongitude, lines[i].srcLatitude, lines[i].destLongitude, lines[i].destLatitude, lines[i].color, lines[i].id);
            }
        }
    }
}

/**
 * 根据瓦片的样式left值，得到画板的left值
 * @param left
 * @returns
 */
function getX(left) {
    return left + parseInt($("#mapContainer").css("left")) + 400;
}

/**
 * 根据瓦片的样式top值，得到画板的top值
 * @param top
 * @returns
 */
function getY(top) {
    return top + parseInt($("#mapContainer").css("top")) + 300;
}

/**
 * 画一条线，此方法为内部调用
 * @param srcLongitude
 * @param srcLatitude
 * @param destLongitude
 * @param destLatitude
 * @param color
 * @param id
 */
function drawLine(srcLongitude, srcLatitude, destLongitude, destLatitude, color, id) {
    if (mapLevel < 12 && id.indexOf("lineB") >= 0) {
        return;
    }
    if (browser == "ie") {
        var pointX = getLeft(srcLongitude, srcLatitude) - 5;
        var pointY = getTop(srcLongitude, srcLatitude) - 10;
        var toX = getLeft(destLongitude, destLatitude) - 5;
        var toY = getTop(destLongitude, destLatitude) - 10;
        if (pointX > toX) {
            var temp = pointX;
            pointX = toX;
            toX = temp;
            temp = pointY;
            pointY = toY;
            toY = temp;
        }
        $("#mapContainer").append('<v:line id=' + id + ' style="position:absolute;top:' + Math.min(pointY, toY) + 'px;left:' + pointX + 'px" from="0,0" to="' + (toX - pointX) + 'px,' + (toY - pointY) + 'px" strokecolor="' + color + '" strokeweight="3px"></v:line>');
    } else {
        var pointX = getX(getLeft(srcLongitude, srcLatitude)) - 5;
        var pointY = getY(getTop(srcLongitude, srcLatitude)) - 10;
        var ctx = document.getElementById("canvasId").getContext("2d");
        ctx.strokeStyle = color;
        ctx.lineWidth = 3;
        ctx.beginPath();
        ctx.moveTo(pointX, pointY);
        pointX = getX(getLeft(destLongitude, destLatitude)) - 5;
        pointY = getY(getTop(destLongitude, destLatitude)) - 10;
        ctx.lineTo(pointX, pointY);
        ctx.closePath();
        ctx.stroke();
    }
}

/**
 * 定位，显示指定区域
 * @param longitude
 * @param latitude
 */
function locateMap(longitude, latitude) {
    var cols = Math.ceil($("#panel").innerWidth() / 256.0) + 2; //要显示的列数
    var rows = Math.ceil($("#panel").innerHeight() / 256.0) + 2; //要显示的行数

    if (cols <= 2) {
        cols = 3;
    }
    if (rows <= 3) {
        rows = 3;
    }
    var temp = convertLL2BlockXy(longitude, latitude);
    var focusColumn = temp[0];
    var focusRow = temp[1];
    var beginRow = focusRow + Math.floor(rows / 2);
    var beginCol = focusColumn - Math.floor(cols / 2);
    focusColumn = beginCol + Math.floor(cols / 2);
    focusRow = beginRow - Math.floor(rows / 2);
    myFocusRow = focusRow;
    myFocusCol = focusColumn;
    if (rows % 2 == 0) {
        containerTop = -128;
    } else {
        containerTop = 0;
    }
    if (cols % 2 == 0) {
        containerLeft = -128;
    } else {
        containerLeft = 0;
    }
    containerTop -= parseInt(((rows - 2) * 256 - $("#panel").innerHeight()) / 2);
    containerLeft -= parseInt(((cols - 2) * 256 - $("#panel").innerWidth()) / 2);


    temp = convertBlockXy2LL(focusColumn + 1, focusRow + 1);
    var maxLongitude = temp[0];
    var maxLatitude = temp[1];
    temp = convertBlockXy2LL(focusColumn, focusRow);
    var minLongitude = temp[0];
    var minLatitude = temp[1];

    containerLeft -= parseInt((longitude - minLongitude) * 256 / (maxLongitude - minLongitude)) - 128;
    containerTop -= parseInt((maxLatitude - latitude) * 256 / (maxLatitude - minLatitude)) - 128;

     //设备的html代码
	var devs=new Array($("[data-covertype='dot']").size());
	$("[data-covertype='dot']").each(function(i){        
		devs[i]=$(this);
	});
    
    $("#mapContainer").css("top", containerTop + "px");
    $("#mapContainer").css("left", containerLeft + "px");
    offsetX = containerLeft;
    offsetY = containerTop;
    $("#mapContainer").empty();

    var fileName, style;
    var row, col;
    var i = 0;
    for (; i < rows; i++) {
        row = beginRow - i;
        for (var j = 0; j < cols; j++) {
            col = beginCol + j;
            fileName = row + "/" + col + ".png";
            style = "left:" + ((j - 1) * 256) + "px;top:" + ((i - 1) * 256) + "px;background-image:url(../img/baidu/" + mapLevel + "/" + fileName + ")";
            if (i == 1 && j == 1) {
                $("#mapContainer").append("<div class='firstTile' id='r" + row + "c" + col + "' style='" + style + "'></div>");
            } else {
                $("#mapContainer").append("<div id='r" + row + "c" + col + "' style='" + style + "'></div>");
            }
        }
    }
    //画板及连线
    if (browser != "ie") {
        $("#mapContainer").append("<canvas id='canvasId'></canvas>");
        var canvas = $("#canvasId");
        canvas.css("top", (-parseInt($("#mapContainer").css("top")) - 300) + "px");
        canvas.css("left", (-parseInt($("#mapContainer").css("left")) - 400) + "px");
        canvas = document.getElementById("canvasId");
        canvas.height = $("#panel").height() + 600;
        canvas.width = $("#panel").width() + 800;
    }
    for (i = 0; i < lines.length; i++) {
        drawLine(lines[i].srcLongitude, lines[i].srcLatitude, lines[i].destLongitude, lines[i].destLatitude, lines[i].color, lines[i].id);
    }   
    
	//加载设备图标
	for(i=0;i<devs.length;i++)
	{
		$("#mapContainer").append(devs[i]);
		longitude=new Number($(devs[i]).attr("longitude"));
		latitude=new Number($(devs[i]).attr("latitude"));
		var id=$(devs[i]).attr("id");
		$(devs[i]).css("top",(getTop(longitude,latitude)-36)+"px");
		$(devs[i]).css("left",(getLeft(longitude,latitude)-25)+"px");
/*		if(id.indexOf('b')==0)
		{
			if(mapLevel==12)
			{
				$(devs[i]).css("display","block");
			}else if(mapLevel==11){
				$(devs[i]).css("display","none");
			}
		}	*/	
	}
}

/**
 * 添加设备图标
 * @param id,交换机以s打头，基站以b打头，邻近交换机以n打头，后面跟数字
 * @param longitude
 * @param latitude
 * @param status:0表示灰，1表示灰闪，2表示绿，3表示绿闪，4表示红，5表示红闪
 * @param devName:设备名字
 */
function addDev(id, longitude, latitude) {

    var top = getTop(longitude, latitude) - 36;
    var left = getLeft(longitude, latitude) - 25;

/*    if (mapLevel < 12) {        
        $(id).css("display", "none");
    } else {
        $(id).removeClass("display");
    }*/

    id.attr("longitude", longitude);
    id.attr("latitude", latitude);
    id.css("top", top);
    id.css("left", left);
    //alert("top: "+top+"; left: "+left);
    id.attr("data-covertype","dot");    
    $("#mapContainer").append(id);
}

/**
 * 初始化地图
 * @param longitude:原点经度
 * @param latitude：原点纬度
 * @param level：地图级别，0：国家，1：省，2：市，3：区县
 */
function mapInit(longitude, latitude, level) {
    switch (level) {
    case 0:
        mapLevel = 6;
        locateMap(longitude, latitude);
        break;
    case 1:
        mapLevel = 9;
        locateMap(longitude, latitude);
        break;
    case 2:
        mapLevel = 10;
        locateMap(longitude, latitude);
        break;
    case 3:
        mapLevel = 12;
        locateMap(longitude, latitude);
        break;
    default:
        return;
    }
    $("#panel").mouseleave(function (e) {
        endDragMap(e);
    });
}