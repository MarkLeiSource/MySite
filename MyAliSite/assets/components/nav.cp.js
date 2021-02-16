Vue.component('my-nav', {
    template: '<nav class="navbar navbar-masthead navbar-default navbar-fixed-top">\
    <div class="container-fluid">\
        <div class="navbar-header">\
          <a class="navbar-brand" href="#">\
            <img alt="Brand" src="/favicon.ico">\
          </a>\
        </div>\
        <div class="collapse navbar-collapse bs-example-masthead-collapse-1">\
            <ul class="nav navbar-nav" >\
                <li class="active"><a href="#">Home <span class="sr-only">(current)</span></a></li>\
                <li v-for="item in Navs"><a href="#">{{item.displayName}}</a></li>\
            </ul>\
        </div>\
    </div>\
    </nav>',
    data: function () {
        return App;
    }
});