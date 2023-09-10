
<template>
  <h1>{{ title }}</h1>
  <p>Welcome...</p>
  <teleport to=".modals" v-if="showModal">
    <Modal theme="sale" @close="toggleModal">
      <template v-slot:links>
        <a href="#">Sign up now</a>
        <a href="#">More info</a>
      </template>
      <h1>Ninja Giveaway</h1>
      <p>Grab your ninja swag for half price!</p>
    </Modal>
  </teleport>
  <teleport to=".modals" v-if="showModal2">
    <Modal @close="toggleModal2">
      <template v-slot:links>
        <a href="#">Delete the internet</a>
        <a href="#">Do something</a>
      </template>
      <h1>Awesome Title</h1>
      <p>Awesome text of the modal</p>
    </Modal>
  </teleport>
  <button @click.alt="toggleModal">Open Modal (alt)</button>
  <button @click="toggleModal2">Open Modal2</button>
  <input type="text" ref="name">
  <button @click="handleClick">Click me</button>
</template>

<script>
/* eslint-disable */
import Modal from './components/Modal.vue'

export default {
  name: 'App',
  components: {
    Modal
  },
  data () {
    return {
      title: 'My first Vue App :)',
      header: 'Sign up for Giveaway!',
      text: 'Grab your ninja swag for half price!',
      showModal: false,
      showModal2: false
    }
  },
  methods: {
    handleClick () {
      console.log(this.$refs.name)
      this.$refs.name.classList.add('active')
      this.$refs.name.focus()
    },
    toggleModal () {
      this.showModal = !this.showModal
    },
    toggleModal2()
    {
      this.showModal2 = !this.showModal2
    }
  }
}
</script>

<style>
#app, .modals {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
h1 {
  border-bottom: 1px solid #ddd;
  display: inline-block;
  padding-bottom: 10px;
}
</style>
