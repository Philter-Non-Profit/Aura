<template>
    <v-card class="mx-auto" max-width="344" :title="title">
        <template v-slot:prepend>
            <v-icon :icon="icon" :color="color"></v-icon>
        </template>
        <v-card-text>
            <slot>
            </slot>
        </v-card-text>
    </v-card>
</template>

<script lang="ts" setup>
withDefaults(
    defineProps<{
        title: string;
        icon: string;
        color?: string;
    }>(),
    {
        color: "primary",
    }
);
</script>