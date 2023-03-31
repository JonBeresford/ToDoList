<template>
    <v-container>
        <v-card class="mx-auto"
                max-width="500">
            <v-list shaped>
                    <template v-for="(item, i) in toDoList">
                        <v-divider v-if="!item"
                                   :key="`divider-${i}`"></v-divider>

                        <v-list-item v-else
                                     :key="`item-${i}`"
                                     :value="item"
                                     active-class="deep-purple--text text--accent-4">
                            <template v-slot:default="{ active, toggle }">
                                <v-list-item-title>item</v-list-item-title>
                                <v-list-item-action>
                                    <v-checkbox :input-value="active"
                                                :true-value="item"
                                                color="deep-purple accent-4"
                                                @click="toggle"></v-checkbox>
                                </v-list-item-action>
                            </template>
                        </v-list-item>
                    </template>
            </v-list>
        </v-card>
    </v-container>
</template>

<script>
import axios from 'axios'

axios.defaults.headers.post['Content-Type'] = 'application/json'
axios.defaults.headers.post.Accept = '*/*'

export default {
  name: 'ToDoListDisplayer',
  data: () => ({
    toDoList: [

    ],
    toDoItem: {
      id: 0,
      name: '',
      description: '',
      isDone: false
    }
  }),
  methods: {
    getToDoList () {
      this.toDoList = axios.get('http://localhost:5000/api/todo')
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
