<template>
  <div class="sms-list">
    <h1>This is the sms list page</h1>
      <SmsHistory />
  </div>
</template>

<script>
// @ is an alias to /src
import SmsHistory from '@/components/SmsHistory.vue'

export default {
  name: 'List',
  components: {
    SmsHistory
  }
}
</script>
