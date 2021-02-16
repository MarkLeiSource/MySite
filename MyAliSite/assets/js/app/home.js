var App = {
    Navs: [{ displayName: '.Net/C#技术', name: 'dotnet' }, {displayName:'C#在线编译', name:'csharp'}, {displayName: 'IoT技术', name: 'iot'}],
    Links: [{displayName: 'mark.lei@live.com', name:'mailto:mark.lei@live.com'}],
    Content: '<div style="min-height:1000px;" class="jumbotron">\
                        <h1> 你好，这里是我的技术分享网站</h1>\
                     <div style="margin-top:50px;">\
                        <p>网站目前处于开发调试阶段，内容即将丰富，敬请期待。</p>\
                        <p > 如果转载网站内容，请表明出处，谢谢。</p>\
                    <div>\
                    </div> ',
    init: function () {
        $.ajax('/rest/home', {
            cache: false,
            method: 'get',          
        }).done(function (data) {
        });
        var vm = new Vue({
            el: '#app',
        });
    }
}
$(function () {
    App.init();
});