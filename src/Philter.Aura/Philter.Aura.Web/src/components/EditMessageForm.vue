<template>
  <c-loader-status :loaders="{ '': [editMessage!.$save] }" />
  <v-card>
    <v-card-title> Create a New Message </v-card-title>
    <v-form ref="form" v-if="editMessage">
      <v-row>
        <v-col cols="12">
          <c-input :model="editMessage" for="messageBody" autofocus></c-input>
        </v-col>
      </v-row>
    </v-form>
  </v-card>

  <v-divider class="my-3" />
  <div class="d-flex justify-end pt-4">
    <slot name="buttons" />
    <v-btn color="primary" variant="elevated" @click="save()"
      ><v-icon icon="fas fa-save" start /> Save
    </v-btn>
  </div>
</template>

<script setup lang="ts">
import { MessageViewModel } from "@/viewmodels.g";
import { VForm } from "vuetify/components";

const props = defineProps<{
  message?: MessageViewModel;
}>();

const emit = defineEmits<{
  (e: "saved"): void;
}>();

const editMessage = computed(() => {
  let message = new MessageViewModel();
  if (props.messageBody) {
    message = props.messageBody;
  }
  return message;
});

const form = ref<VForm>();

onMounted(() => {
  (form.value as VForm)?.validate();
});

async function save() {
  await editMessage!.value!.$save();
  emit("saved");
}
</script>
