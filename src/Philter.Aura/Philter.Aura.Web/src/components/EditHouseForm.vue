<template>
    <c-loader-status :loaders="{ '': [editHouse!.$save] }" />
    <v-form ref="form" v-if="editHouse">
        <v-row>
            <v-col cols="12">
                <c-input :model="editHouse" for="name" autofocus></c-input>
            </v-col>
            <v-col cols="12">
                <c-input :model="editHouse" for="address" textarea min="0"></c-input>
            </v-col>
            <v-col cols="6">
                <c-input :model="editHouse" for="mainPhone"></c-input>
            </v-col>
            <v-col cols="6">
                <c-input :model="editHouse" for="altPhone"></c-input>
            </v-col>
        </v-row>
    </v-form>

    <div class="d-flex justify-end pt-4">
        <v-btn color="primary" variant="elevated" @click="save()"><v-icon icon="fas fa-save" start /> Save </v-btn>
    </div>
</template>

<script setup lang="ts">
import { HouseViewModel } from "@/viewmodels.g";
import { VForm } from "vuetify/components";

const props = defineProps<{
    house?: HouseViewModel;
}>();

const editHouse = ref<HouseViewModel>();
const isNew = computed(() => !props.house?.houseId);

if (!isNew) { editHouse.value = props.house; }
else { editHouse.value = new HouseViewModel(); }

const form = ref<VForm>();

async function save() {
    await editHouse!.value!.$save();
}
</script>