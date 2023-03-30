<template>
  <div class="ToDo">
    <h1>Add Your Todo Items</h1>
    <toDoList />
  </div>
</template>

<script>
// @ is an alias to /src
import ToDoList from '@/components/ToDoList.vue'

export default {
  name: 'ToDo',
  components: {
    ToDoList
  }
}
</script>
