<template>
    <div class="container">
        <h1>Pending Items</h1>
        <div class="todo-list">
            <div class="main">
                <div v-for="item in pendingList"
                     :key="item.id">
                    {{ item.name }}  - {{ item.description }} :
                    <input type="checkbox" v-model="item.isDone"
                           :class="{ notclicked: !item.isDone, clicked: item.isDone }"
                           @click="toggleClick(item)">
                </div>
            </div>
        </div>
        <div></div>
        <h1>Done Items</h1>
        <div class="todo-list">
            <div class="main">
                <div v-for="item in doneList"
                     :key="item.id">
                    {{ item.name }}  - {{ item.description }} :
                    <input type="checkbox" v-model="item.isDone"
                           :class="{ notclicked: !item.isDone, clicked: item.isDone }"
                           @click="toggleClick(item)">
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios'

axios.defaults.headers.post['Content-Type'] = 'application/json'
axios.defaults.headers.post.Accept = '*/*'

export default {
  name: 'ToDoListDisplayer',
  data: () => ({
    toDoList: [{ id: 0, name: 'fuck off', isDone: false }]
  }),
  computed: {
    doneList: function () {
      return this.toDoList.filter(item => item.isDone === true)
    },
    pendingList: function () {
      return this.toDoList.filter(item => item.isDone === false)
    }
  },
  methods: {
    toggleClick (item) {
      item.isDone = !item.isDone
    },
    getToDoList () {
      return axios.get('http://localhost:5000/api/todo')
        .then(response => (this.toDoList = [...response.data]))
        .catch(error => console.log(error))
    }
  },
  beforeMount () {
    this.getToDoList()
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="stylus">
</style>
