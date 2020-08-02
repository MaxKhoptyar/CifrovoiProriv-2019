$(document).ready(function() {

$('.color-item').hover(function(e){

    var id = '.'+$(this).data('id');
    $('path').addClass('path-deactive');
    $(id).removeClass('path-deactive').addClass('path-active');

},function(){
    $('.indicator').html('');
    $('.indicator').hide();
 
    $('path').removeClass('path-active');
    $('path').removeClass('path-deactive');
});


$('path').hover(function(e){
    
    $('.indicator').html('');
    var id = $(this).attr('id').toUpperCase();

    if($(this).attr('name')) {
        var name = $(this).attr('name');
        $('<div>' + name +'</div>').appendTo('.indicator');
    }

    /*Изображения областей
        if($(this).attr('flag')) {
            var flag = "/hakaton/flag/" + $(this).attr('flag') ;
            $(' <img class="flag" src="" alt="">').appendTo('.indicator');
            $('.indicator').find('img').attr('src',flag );
        }
    */
    
    $('.change').remove();

    $(this).addClass("path-active");
    $('path').not(this).addClass('path-deactive');
    
    var rightw = $( window ).width() - e.pageX;
    
    if (rightw > '300' ) {
        $('.indicator').css({'top':e.pageY,'left':e.pageX+10}).show();
    } else {
        $('.indicator').css({'top':e.pageY,'left':e.pageX-200}).show();
    }

},function(){
    $('.indicator').html('');
    $('.indicator').hide();
 
    $(this).removeClass('path-active');
    $('path').removeClass('path-deactive');
});


var idAarr = ["RU-MOW", "RU-SPE", "RU-NEN", "RU-YAR", "RU-CHE", "RU-ULY", "RU-TYU", "RU-TUL", "RU-SVE", "RU-RYA", "RU-ORL", "RU-OMS", "RU-NGR", "RU-LIP", "RU-KRS", "RU-KGN", "RU-KGD", "RU-IVA", "RU-BRY", "RU-AST", "RU-KHA", "RU-CE", "RU-UD", "RU-SE", "RU-MO", "RU-KR", "RU-KL", "RU-IN", "RU-AL", "RU-BA", "RU-AD", "RU-CR", "RU-SEV", "RU-KO", "RU-KIR", "RU-PNZ", "RU-TAM", "RU-MUR", "RU-LEN", "RU-VLG", "RU-KOS", "RU-PSK", "RU-ARK", "RU-YAN", "RU-CHU", "RU-YEV", "RU-TY", "RU-SAK", "RU-AMU", "RU-BU", "RU-KK", "RU-KEM", "RU-NVS", "RU-ALT", "RU-DA", "RU-STA", "RU-KB", "RU-KC", "RU-KDA", "RU-ROS", "RU-SAM", "RU-TA", "RU-ME", "RU-CU", "RU-NIZ", "RU-VLA", "RU-MOS", "RU-KLU", "RU-BEL", "RU-ZAB", "RU-PRI", "RU-KAM", "RU-MAG", "RU-SA", "RU-KYA", "RU-ORE", "RU-SAR", "RU-VGG", "RU-VOR", "RU-SMO", "RU-TVE", "RU-PER", "RU-KHM", "RU-TOM", "RU-IRK"];
var idAarr2 = new Array(
  ["RU-MOW",  "Москва", "moscow.gif"],
  ["RU-CHE", "Челябинская область", "chelyabinskaya_flag.png" ],
  ["RU-ORL",  "Орловская область"],
  ["RU-OMS",  "Омская область", "flag_omskoj_oblasti.png"],
  ["RU-LIP",  "Липецкая область", "lipeckya.jpg"],
  ["RU-KRS",  "Курская область", "flag_of_kursk_oblast.png"],
  ["RU-RYA",  "Рязанская область", "ryazan.png"],
  ["RU-BRY",  "Брянская область", "bryanskaya_flag.png"],
  ["RU-KIR",  "Кировская область", "flag_kirovskoy_oblasti.png"],
  ["RU-ARK",  "Архангельская область", ""],
  ["RU-MUR",  "Мурманская область", ""],
  ["RU-SPE",  "Санкт-Петербург", ""],
  ["RU-YAR",  "Ярославская область", ""],
  ["RU-ULY",  "Ульяновская область", ""],
  ["RU-NVS",  "Новосибирская область", ""],
  ["RU-TYU",  "Тюменская область", ""],
  ["RU-SVE",  "Свердловская область", ""],
  ["RU-NGR",  "Новгородская область", ""],
  ["RU-KGN",  "Курганская область", ""],
  ["RU-KGD",  "Калининградская область", ""],
  ["RU-IVA",  "Ивановская область", ""],
  ["RU-AST",  "Астраханская область", ""],
  ["RU-KHA",  "Хабаровский край", ""],
  ["RU-CE",  "Чеченская республика", ""],
  ["RU-UD",  "Удмуртская республика", ""],
  ["RU-SE",  "Республика Северная Осетия", ""],
  ["RU-MO",  "Республика Мордовия", ""],
  ["RU-KR",  "Республика  Карелия", ""],
  ["RU-KL",  "Республика  Калмыкия", ""],
  ["RU-IN",  "Республика  Ингушетия", ""],
  ["RU-AL",  "Республика Алтай", ""],
  ["RU-BA",  "Республика Башкортостан", ""],
  ["RU-AD",  "Республика Адыгея", ""],
  ["RU-CR",  "Республика Крым", ""],
  ["RU-SEV",  "Севастополь", ""],
  ["RU-KO",  "Республика Коми", ""],
  ["RU-PNZ",  "Пензенская область", ""],
  ["RU-TAM",  "Тамбовская область", ""],
  ["RU-LEN",  "Ленинградская область", ""],
  ["RU-VLG",  "Вологодская область", ""],
  ["RU-KOS",  "Костромская область", ""],
  ["RU-PSK",  "Псковская область", ""],
  ["RU-YAN",  "Ямало-Ненецкий АО", ""],
  ["RU-CHU",  "Чукотский АО", ""],
  ["RU-YEV",  "Еврейская автономная область", ""],
  ["RU-TY",  "Республика Тыва", ""],
  ["RU-SAK",  "Сахалинская область", ""],
  ["RU-AMU",  "Амурская область", ""],
  ["RU-BU",  "Республика Бурятия", ""],
  ["RU-KK",  "Республика Хакасия", ""],
  ["RU-KEM",  "Кемеровская область", ""],
  ["RU-ALT",  "Алтайский край", ""],
  ["RU-DA",  "Республика Дагестан", ""],
  ["RU-KB",  "Кабардино-Балкарская республика", ""],
  ["RU-KC",  "Карачаево-Черкесская республика", ""],
  ["RU-KDA",  "Краснодарский край", ""],
  ["RU-ROS",  "Ростовская область", ""],
  ["RU-SAM",  "Самарская область", ""],
  ["RU-TA",  "Республика Татарстан", ""],
  ["RU-ME",  "Республика Марий Эл", ""],
  ["RU-CU",  "Чувашская республика", ""],
  ["RU-NIZ",  "Нижегородская край", ""],
  ["RU-VLA",  "Владимирская область", ""],
  ["RU-MOS",  "Московская область", ""],
  ["RU-KLU",  "Калужская область", ""],
  ["RU-BEL",  "Белгородская область", ""],
  ["RU-ZAB",  "Забайкальский край", ""],
  ["RU-PRI",  "Приморский край", ""],
  ["RU-KAM",  "Камачатский край", ""],
  ["RU-MAG",  "Магаданская область", ""],
  ["RU-SA",  "Республика Саха (Якутия)", ""],
  ["RU-KYA",  "Красноярский край", ""],
  ["RU-ORE",  "Оренбургская область", ""],
  ["RU-SAR",  "Саратовская область", ""],
  ["RU-VGG",  "Волгоградская область", ""],
  ["RU-VOR",  "Ставропольский край", ""],
  ["RU-SMO",  "Смоленская область", ""],
  ["RU-TVE",  "Тверская область", ""],
  ["RU-PER",  "Пермская область", ""],
  ["RU-KHM",  "Ханты-Мансийский АО", ""],
  ["RU-KHM",  "Ханты-Мансийский АО", ""],
  ["RU-TOM",  "Томская область", ""],
  ["RU-IRK",  "Иркутская область", ""],
  ["RU-NEN",  "Ненецский АО", ""],
  ["RU-STA",  "Ставропольский край", ""],
  ["RU-TUL",  "Тульская область", "tulskaya_flag.png"]

  );
  

    num =  0;
$('path').each(function() {
  num =  num + 1
  var regId = $(this).attr('id');
  var flag = '';
  var name = '';
  for (var j = 0; j < idAarr2.length; j++) {

    if (regId == idAarr2[j][0]) {
      name = idAarr2[j][1];
      flag =  idAarr2[j][2];

      $(this).attr('name', name);
      $(this).attr('flag', flag);
    }
  }

 // var regIdDiv = '<div data-id="' + regId + '" class="reg" >'+ '[' + '<span>'+  num +'</span>' + ']' +' '+ name +'</div>'
 // $(regIdDiv).appendTo('.regs');

var regIdDiv2 = '<option value="' + regId + '" class="reg-list-item" data-id="' + regId + '" data-tokens="'+ name +'">'+ name +'</option>';
  $(regIdDiv2).appendTo('.reg-list');  
  

})



$( ".reg-list" ).change(function() {
    $('path').removeClass('path-active');
    var id = $(this).val();
    if(id === '0'){
        $('path').removeClass('path-active');
        $('path').removeClass('path-deactive');
        return false;
    }
    idHover = '#' + id;
    $('path').addClass('path-deactive');
    $(idHover).removeClass('path-deactive').addClass('path-active');
    
});

/*
$('.reg').hover(function(e) {
    var id = $(this).data('id');
    idHover = '#' + id;
    //$(idHover).css('fill','#552df6');
    $('path').addClass('path-deactive');
    $(idHover).removeClass('path-deactive').addClass('path-active');
},function(){
    $('.indicator').html('');
    $('.indicator').hide();
   // $('path').css('fill','rgba(0,0,0,0.2)');
    
    $('path').removeClass('path-active');
    $('path').removeClass('path-deactive');
});
*/

function Rand(min, max) {
  return Math.floor(Math.random() * (max - min + 1)) + min;
}


function colorstat() {
    $('path').each(function() {
      //var color = new Array( ["#ff515a"], ["#56b9b2"], ["#ffc483"], ["#e00132"], ["#338b79"] );
      var colorint = Rand(1, 10);
      
      $(this).addClass("color"+colorint);
    });
}

//colorstat();


$('path').click(function() {
    var region = $(this).attr('id');
    openregion(region);
});

function openregion(region) {
    var url = '/Statistic/Region?regionNumber=' + region;
   location.href=url;
}


$('.index-map-item').click(function() {
    var param = $(this).data('id');
    openmap(param);
});

function openmap(param) {
    var url = '/Statistic/Index?mapNumber=' + param;
   location.href=url;
}

$(".metr-list").change(function () {
    var id = $(this).val();
    openmap(id);
});

});

function Rand(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function migmap() {
    var idAarr = ["RU-MOW", "RU-SPE", "RU-NEN", "RU-YAR", "RU-CHE", "RU-ULY", "RU-TYU", "RU-TUL", "RU-SVE", "RU-RYA", "RU-ORL", "RU-OMS", "RU-NGR", "RU-LIP", "RU-KRS", "RU-KGN", "RU-KGD", "RU-IVA", "RU-BRY", "RU-AST", "RU-KHA", "RU-CE", "RU-UD", "RU-SE", "RU-MO", "RU-KR", "RU-KL", "RU-IN", "RU-AL", "RU-BA", "RU-AD", "RU-CR", "RU-SEV", "RU-KO", "RU-KIR", "RU-PNZ", "RU-TAM", "RU-MUR", "RU-LEN", "RU-VLG", "RU-KOS", "RU-PSK", "RU-ARK", "RU-YAN", "RU-CHU", "RU-YEV", "RU-TY", "RU-SAK", "RU-AMU", "RU-BU", "RU-KK", "RU-KEM", "RU-NVS", "RU-ALT", "RU-DA", "RU-STA", "RU-KB", "RU-KC", "RU-KDA", "RU-ROS", "RU-SAM", "RU-TA", "RU-ME", "RU-CU", "RU-NIZ", "RU-VLA", "RU-MOS", "RU-KLU", "RU-BEL", "RU-ZAB", "RU-PRI", "RU-KAM", "RU-MAG", "RU-SA", "RU-KYA", "RU-ORE", "RU-SAR", "RU-VGG", "RU-VOR", "RU-SMO", "RU-TVE", "RU-PER", "RU-KHM", "RU-TOM", "RU-IRK"];
    var rnum = Rand(0, 85);
    // console.log(idAarr[rnum]);

    $('#' + idAarr[rnum]).addClass('migcolor');
    //setTimeout( rmvcl('#'+idAarr[rnum]) , 25000);

    function rmvcl(path) {
        console.log(idAarr[rnum]);
        $(path).removeClass('migcolor');
    }
}

function num_to(id, from, to, duration) {
    var currentNumber = from;

    $({ numberValue: currentNumber }).animate({ numberValue: to }, {
        duration: duration,
        easing: 'linear',
        step: function () {

            $(id).text(Math.ceil(this.numberValue));
            migmap();
        }
    });
}
//вызов функции
$(document).ready(function () {

    num_to("#Vse", 124050, 146880432, 14688043200);
});


function crds(crd, callback) {
    return ymaps.geocode(crd)
        .then(function (res) {
            return res.geoObjects.get(0).geometry.getCoordinates();
        });
}




 
// Список адресов
adrsList = [{
    "adrs": "Выставочная ул., 1, село Большие Кабаны",
    "name": "Казань expo"
}, {
    "adrs": "Казань, улица Батурина, 7",
    "name": "ЦИК Республики Татарстан"
}, {
    "adrs": "Казань, Волгоградская улица, 32",
    "name": "ТИК Авиастроительного района города Казани"
}, {
    "adrs": "Казань, Ипподромная улица, 18",
    "name": "ТИК Вахитовского района города Казани"
}, {
    "adrs": "Казань, улица Восстания, 82",
    "name": "ТИК Кировского района города Казани"
}, {
    "adrs": "Казань, улица Восстания, 82",
    "name": "ТИК Московского района города Казани"
}, {
    "adrs": "Казань, Волгоградская улица, 32",
    "name": "ТИК Ново-Савиновского района города Казани"
}, {
    "adrs": "Казань, Ипподромная улица, 18",
    "name": "ТИК Приволжского района города Казани"
}, {
    "adrs": "Казань, улица Шуртыгина, 1",
    "name": "ТИК Советского района города Казани"
}];



var myMap;

// Дождёмся загрузки API и готовности DOM.
ymaps.ready(init);

function init () {

    myMap = new ymaps.Map('map', {
        center: [55.7963,49.1088],
        zoom: 10
    }, { searchControlProvider: 'yandex#search' });

    k = 0;
    for ( i = 0; i < adrsList.length; i++) {
 
        var cityCollection = new ymaps.GeoObjectCollection();
        var geocoder = ymaps.geocode(adrsList[i].adrs, {results: 1});
        
        geocoder.then( function (res) {
            var coordinates = res.geoObjects.get(0).geometry.getCoordinates();
            var Placemark = new ymaps.Placemark(coordinates, { hintContent: adrsList[k].adrs, balloonContent: '<h3>' + adrsList[k].name + '</h3><div style="">' + adrsList[k].adrs + '</div><div style="">(' + k + ') ' + coordinates + '</div>' }, {
                iconLayout: 'default#image', iconImageHref: 'https://bud-online.ru/hakaton/img/mapicon.png', iconImageSize: [50, 52],
                iconImageOffset: [-3, -42] } );
            cityCollection.add(Placemark);
            k++;        
        });
   
    }
    myMap.geoObjects.add(cityCollection);    
    myMap.setBounds(cityCollection.getBounds());
    myCollection.options.set("preset", "twirl#redIcon");
}
