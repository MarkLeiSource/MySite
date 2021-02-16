Vue.component('my-content', {
    template: '<div v-html="Content"></div>',
    data: function () {
        return App;
    }
});