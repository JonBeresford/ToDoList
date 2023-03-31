<template>
  <div class="ToDo">
    <h1>Add Your Todo Items</h1>
    <ToDoListComposer />
    <ToDoListDisplayer />
  </div>
</template>

<script>
// @ is an alias to /src
import ToDoListComposer from '@/components/ToDoListComposer.vue'
import ToDoListDisplayer from '@/components/ToDoListDisplayer.vue'

export default {
  name: 'ToDo',
  components: {
    ToDoListComposer,
    ToDoListDisplayer
  }
}
</script>
