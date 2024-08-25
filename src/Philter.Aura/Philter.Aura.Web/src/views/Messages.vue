<template>
  <EditMessageForm />
  <v-row v-for="message in messageList">
    <v-col>message data</v-col>
  </v-row>
</template>

<script setup lang="ts">
import { MessageListViewModel } from "@/viewmodels.g";

useTitle("Messages");

const messageList = ref<MessageListViewModel>();
messageList.value = new MessageListViewModel();
messageList.value.$pageSize = 100;
messageList.value.$load();

const message = computed(() => messageList.value?.$items[0]);

function loadMessages() {
  messageList.value?.$load();
}
</script>
