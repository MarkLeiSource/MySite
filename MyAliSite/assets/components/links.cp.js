Vue.component('my-links', {
    template: '<ul class="nav nav-pills nav-stacked">\
        <li v-for="item in Links"><a v-bind:href="item.name">{{ item.displayName }}</a></li>\
    </ul>',
	data: function () {
		return App;
	}
});