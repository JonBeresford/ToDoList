<template>
    <v-container class="todolist-composer">

            <v-layout row wrap>

                <v-form @submit.prevent="addToDoItem">
                    <v-text-field v-model="todoItem.name"
                                  label="Item Name"></v-text-field>
                    <v-textarea v-model="todoItem.description"
                                label="Description"></v-textarea>
                    <button type="submit">Add Item</button>
                </v-form>

            </v-layout>

    </v-container>
</template>

<script>
import axios from 'axios'

axios.defaults.headers.post['Content-Type'] = 'application/json'
axios.defaults.headers.post.Accept = '*/*'

export default {
  name: 'ToDoListComposer',
  data: () => ({
    todoItem: {
      name: '',
      description: ''
    }
  }),
  methods: {
    addToDoItem () {
      axios.post('http://localhost:5000/api/todo', this.todoItem)
        .then(response => console.log(response))
        .catch(error => console.log(error))

      this.todoItem = {
        name: '',
        description: ''
      }
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="stylus">
</style>
