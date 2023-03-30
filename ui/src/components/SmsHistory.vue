<template>
  <v-container class="sms-history">
    <v-layout row wrap>
        <v-flex xs12>
            <vue-good-table
                   :columns="columns"
                   :rows="rows" />
        </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import axios from 'axios'
import Vue from 'vue'
import VueGoodTablePlugin from 'vue-good-table'
// import the styles
import 'vue-good-table/dist/vue-good-table.css'
Vue.use(VueGoodTablePlugin)

axios.defaults.headers.post['Content-Type'] = 'application/json'
axios.defaults.headers.post['Accept'] = '*/*'

export default {
  name: 'SmsHistory',
  data: () => ({
    columns: [
      {
        label: 'Sent To',
        field: 'toPhoneNumber'
      },
      {
        label: 'Message Text',
        field: 'message'
      },
      {
        label: 'Sent On',
        field: 'sentDate',
        type: 'datetime'
      }

    ],
    rows: []
  }
  ),
  methods: {
    getSmsHistory () {
      this.rows = axios.get('http://localhost:5000/api/sms')
        .then(response => (this.rows = [...response.data]))
        .catch(error => console.log(error))
    }
  },
  beforeMount () {
    this.getSmsHistory()
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="stylus">
</style>
