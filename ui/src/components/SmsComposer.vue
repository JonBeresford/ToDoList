<template>
  <v-container class="sms-composer">
    <v-layout row wrap>
      <v-flex xs12>
        <v-form v-model="valid" @submit.prevent="sendSms">
          <v-text-field
            v-model="twilioMsg.toPhoneNumber"
            label="Mobile Number"
           ></v-text-field>
          <v-textarea
             v-model="twilioMsg.message"
            label="Sms Content"
          ></v-textarea>
            <button type="submit">Send SMS</button>
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
  name: 'SmsComposer',
  data: () => ({
    valid: true,
    twilioMsg: {
      toPhoneNumber: '',
      message: ''
    }
  }),
  methods: {
    sendSms () {
      axios.post('http://localhost:5000/api/sms', this.twilioMsg)
        .then(response => console.log(response))
        .catch(error => console.log(error))

      this.twilioMsg = {
        toPhoneNumber: '',
        message: ''
      }
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="stylus">
</style>
