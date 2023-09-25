<script setup lang="ts">
import { ref } from 'vue'
import EditInput from './EditUtils/EditInput.vue'
import EditContainer from './EditUtils/EditContainer.vue';
import EditTextArea from './EditUtils/EditTextArea.vue';

const { modelValue } = defineProps({
    modelValue: {
        type: Object as () => { heading: string, body: string },
        required: true
    }
})


const emit = defineEmits(['update:modelValue'])
const sectionHeader = ref(modelValue.heading)
const sectionBody = ref(modelValue.body)

const updateHeader = (e: any) => {
    emit('update:modelValue', { heading: e, body: sectionBody.value })
}

const updateBody = (e: any) => {
    emit('update:modelValue', { heading: sectionHeader.value, body: e })
}


</script>

<template>
    <EditContainer :label="sectionHeader" type="Post Section">
        <EditInput label="Section Header" v-on:update:modelValue="updateHeader" v-model="sectionHeader" />
        <EditTextArea label="Section Body" v-on:update:modelValue="updateBody" v-model="sectionBody" />
    </EditContainer>
</template>