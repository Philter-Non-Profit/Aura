<template>
    <v-dialog max-width="800px" scrollable>
        <v-card>
            <v-card-item class="bg-primary pt-4 pb-3">
                <v-row>
                    <v-col cols="12" class="my-auto">
                        <v-card-title> {{ title }} </v-card-title>
                    </v-col>
                </v-row>
            </v-card-item>
            <v-card-text class="py-4">
                <slot />
            </v-card-text>
        </v-card>
    </v-dialog>
</template>
  
<script setup lang="ts">
defineProps<{
    title: string;
}>();
</script>