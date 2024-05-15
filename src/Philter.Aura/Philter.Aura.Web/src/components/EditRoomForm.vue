<template>
    <c-loader-status :loaders="{ '': [editRoom!.$save] }" />
    <v-form ref="form" v-if="editRoom">
        <v-row>
            <v-col cols="12">
                <c-input :model="editRoom" for="name" autofocus></c-input>
            </v-col>
            <v-col cols="12">
                <c-input :model="editRoom" for="notes" textarea min="0"></c-input>
            </v-col>
        </v-row>
    </v-form>

    <v-divider class="my-3" />
    <div class="d-flex justify-end pt-4">
        <slot name="buttons" />
        <v-btn color="primary" variant="elevated" @click="save()"><v-icon icon="fas fa-save" start /> Save </v-btn>
    </div>
</template>

<script setup lang="ts">
import { RoomViewModel } from "@/viewmodels.g";
import { VForm } from "vuetify/components";

const props = defineProps<{
    room?: RoomViewModel;
    houseId: number;
}>();

const emit = defineEmits<{
    (e: "saved"): void;
}>();

const editRoom = computed(() => {
    let room = new RoomViewModel();
    room.houseId = props.houseId;
    if (props.room) { room = props.room; }
    return room;
});

const form = ref<VForm>();

onMounted(() => {
    (form.value as VForm)?.validate();
});

async function save() {
    await editRoom!.value!.$save();
    emit("saved");
}
</script>