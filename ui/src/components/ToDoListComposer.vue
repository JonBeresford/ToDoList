<template>
  <v-container class="todo-composer">
    <v-layout row wrap>
      <v-flex xs12>
        <v-form v-model="valid" @submit.prevent="addToDoItem">
          <v-text-field
            v-model="todo.name"
            label="Item Name"
           ></v-text-field>
          <v-textarea
             v-model="todo.description"
            label="Description"
          ></v-textarea>
            <button type="submit">Add Item</button>
        </v-form>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import axios from 'axios'

axios.defaults.headers.post['Content-Type'] = 'application/json'
axios.defaults.headers.post['Accept'] = '*/*'

export default {
  name: 'ToDoListComposer',
  data: () => ({
    valid: true,
    toDo: {
        name: '',
        description: ''
    }
  }),
  methods: {
      addToDoItem () {
          axios.post('http://localhost:5000/api/todo', this.todo)
        .then(response => console.log(response))
        .catch(error => console.log(error))

   this.todo = {
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
