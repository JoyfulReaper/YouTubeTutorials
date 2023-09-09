const app = Vue.createApp({
    // Data, functions
    // template: '<h2>I am the template</h2>'
    data() {
        return {
            url: 'https://kgivler.com',
            showBooks: true,
            books: [
                { title: 'name of the wind', author: 'patrick rothfuss', img: 'assets/1.jpg', isFav: true },
                { title: 'the way of kings', author: 'Brandon Sanderson', img: 'assets/2.jpg', isFav: false },
                { title: 'the final empire', author: 'Brandon Sanderson', img: 'assets/3.jpg', isFav: true },
            ],
            title: 'The Final Empire',
            author: 'Brandon Sanderson',
            age: 45,
            x: 0,
            y: 0,
        }
    },
    methods: {
        changeTitle(title) {
            this.title = title
        },
        toggleShowBooks() {
            this.showBooks = !this.showBooks
        },
        handleEvent(e, data) {
            console.log(e, e.type)
            if (data) {
                console.log(data)
            }
        },
        handleMousemove(e) {
            this.x = e.offsetX
            this.y = e.offsetY
        },
        toggleFav(book) {
            book.isFav = !book.isFav
        }
    },
    computed: {
        filteredBooks() {
            return this.books.filter((book) => book.isFav)
        }
    }
})

app.mount('#app')