<script setup lang="ts">
import { ref } from 'vue'
import EditContainer from './EditUtils/EditContainer.vue';
import EditList from './EditUtils/EditList.vue';

const items = ref<string[]>(["", ""]);

</script>

<template>
    <EditContainer label="Centered Ordered list" type="Centered Ordered list">
        <EditList label="Steps" v-model="items" />
    </EditContainer>
</template>